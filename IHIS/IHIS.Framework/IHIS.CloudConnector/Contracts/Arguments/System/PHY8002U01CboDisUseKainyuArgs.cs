using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class PHY8002U01CboDisUseKainyuArgs : IContractArgs
    {
        protected bool Equals(PHY8002U01CboDisUseKainyuArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PHY8002U01CboDisUseKainyuArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public PHY8002U01CboDisUseKainyuArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY8002U01CboDisUseKainyuRequest();
        }
    }
}