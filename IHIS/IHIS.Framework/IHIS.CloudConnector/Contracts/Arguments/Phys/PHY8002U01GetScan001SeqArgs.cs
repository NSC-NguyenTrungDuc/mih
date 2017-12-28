using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY8002U01GetScan001SeqArgs : IContractArgs
    {
    protected bool Equals(PHY8002U01GetScan001SeqArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY8002U01GetScan001SeqArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public PHY8002U01GetScan001SeqArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY8002U01GetScan001SeqRequest();
        }
    }
}