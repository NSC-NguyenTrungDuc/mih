using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U31GetTemplateTagsArgs : IContractArgs
    {
        private String _emrTemplateId;

        public String EmrTemplateId
        {
            get { return this._emrTemplateId; }
            set { this._emrTemplateId = value; }
        }

        public OCS2015U31GetTemplateTagsArgs() { }

        public OCS2015U31GetTemplateTagsArgs(String emrTemplateId)
        {
            this._emrTemplateId = emrTemplateId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U31GetTemplateTagsRequest();
        }
    }
}