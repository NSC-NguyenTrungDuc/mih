using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0311U00FwkDanuiArgs : IContractArgs
    {
    protected bool Equals(OCS0311U00FwkDanuiArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0311U00FwkDanuiArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public OCS0311U00FwkDanuiArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0311U00FwkDanuiRequest();
        }
    }
}