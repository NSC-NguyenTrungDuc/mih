using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class ComboCplsCboPartArgs : IContractArgs
    {
    protected bool Equals(ComboCplsCboPartArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ComboCplsCboPartArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public ComboCplsCboPartArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ComboCplsCboPartRequest();
        }
    }
}