using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV4001LoadBuseoArgs : IContractArgs
    {

        public INV4001LoadBuseoArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV4001LoadBuseoRequest();
        }
    }
}