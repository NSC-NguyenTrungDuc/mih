using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class BIL2016U00FindBoxGroupArgs : IContractArgs
    {

        public BIL2016U00FindBoxGroupArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL2016U00FindBoxGroupRequest();
        }
    }
}