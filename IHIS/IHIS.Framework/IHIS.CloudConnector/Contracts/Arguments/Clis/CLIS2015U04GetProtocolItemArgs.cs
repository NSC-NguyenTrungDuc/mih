using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U04GetProtocolItemArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U04GetProtocolItemArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U04GetProtocolItemArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public CLIS2015U04GetProtocolItemArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U04GetProtocolItemRequest();
        }
    }
}