using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class OCS0132GetServerIpArgs : IContractArgs
    {
        protected bool Equals(OCS0132GetServerIpArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OCS0132GetServerIpArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public OCS0132GetServerIpArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0132GetServerIpRequest();
        }
    }
}