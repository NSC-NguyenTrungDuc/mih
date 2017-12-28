using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U31EmrTemplateTypeResult : AbstractContractResult
    {
        private List<OCS2015U31EmrTemplateTypeInfo> _emrTemplateTypeInfo = new List<OCS2015U31EmrTemplateTypeInfo>();

        public List<OCS2015U31EmrTemplateTypeInfo> EmrTemplateTypeInfo
        {
            get { return this._emrTemplateTypeInfo; }
            set { this._emrTemplateTypeInfo = value; }
        }

        public OCS2015U31EmrTemplateTypeResult() { }

    }
}