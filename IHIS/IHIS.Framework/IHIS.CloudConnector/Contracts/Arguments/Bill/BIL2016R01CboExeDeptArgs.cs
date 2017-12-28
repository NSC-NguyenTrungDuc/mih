using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class BIL2016R01CboExeDeptArgs : IContractArgs
    {

        public BIL2016R01CboExeDeptArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL2016R01CboExeDeptRequest();
        }
    }
}