using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTLayconstantConstArgs : IContractArgs
    {
    protected bool Equals(OCSACTLayconstantConstArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSACTLayconstantConstArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public OCSACTLayconstantConstArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTLayconstantConstRequest();
        }
    }
}