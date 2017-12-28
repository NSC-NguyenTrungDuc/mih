using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class BIL0102U00PrintTemplateArgs : IContractArgs
    {

        public BIL0102U00PrintTemplateArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL0102U00PrintTemplateRequest();
        }
    }
}