using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class PHY8002U01CboDisUseADLArgs : IContractArgs
    {
        protected bool Equals(PHY8002U01CboDisUseADLArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PHY8002U01CboDisUseADLArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public PHY8002U01CboDisUseADLArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY8002U01CboDisUseADLRequest();
        }
    }
}