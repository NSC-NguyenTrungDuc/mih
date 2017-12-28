using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U31GetTemplateTagsResult : AbstractContractResult
    {
        private List<OCS2015U31GetTemplateTagsInfo> _temTagRootItemInfo = new List<OCS2015U31GetTemplateTagsInfo>();
        private List<OCS2015U31GetTemplateTagsInfo> _temTagNodeItemInfo = new List<OCS2015U31GetTemplateTagsInfo>();

        public List<OCS2015U31GetTemplateTagsInfo> TemTagRootItemInfo
        {
            get { return this._temTagRootItemInfo; }
            set { this._temTagRootItemInfo = value; }
        }

        public List<OCS2015U31GetTemplateTagsInfo> TemTagNodeItemInfo
        {
            get { return this._temTagNodeItemInfo; }
            set { this._temTagNodeItemInfo = value; }
        }

        public OCS2015U31GetTemplateTagsResult() { }

    }
}