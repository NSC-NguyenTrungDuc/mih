using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV0101U01LoadComboArgs : IContractArgs
    {

        public INV0101U01LoadComboArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV0101U01LoadComboRequest();
        }
    }
}