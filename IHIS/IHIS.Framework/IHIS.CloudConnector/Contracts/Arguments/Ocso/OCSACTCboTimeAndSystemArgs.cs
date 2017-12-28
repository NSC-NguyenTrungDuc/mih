using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    [Serializable]
    public class OCSACTCboTimeAndSystemArgs : IContractArgs
    {
        protected bool Equals(OCSACTCboTimeAndSystemArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OCSACTCboTimeAndSystemArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public OCSACTCboTimeAndSystemArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTCboTimeAndSystemRequest();
        }
    }
}