using System;
using IHIS.CloudConnector.Contracts.Models.INVS;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.INVS
{
    public class INV6002U00GrdINV6002LoadcbxActorArgs : IContractArgs
    {

        public INV6002U00GrdINV6002LoadcbxActorArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV6002U00GrdINV6002LoadcbxActorRequest();
        }
    }
}