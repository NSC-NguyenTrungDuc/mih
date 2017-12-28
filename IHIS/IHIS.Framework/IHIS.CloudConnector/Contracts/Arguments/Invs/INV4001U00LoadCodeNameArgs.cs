using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV4001U00LoadCodeNameArgs : IContractArgs
    {

        public INV4001U00LoadCodeNameArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV4001U00LoadCodeNameRequest();
        }
    }
}