using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class DOC4003U00GetNextValArgs : IContractArgs
    {
    protected bool Equals(DOC4003U00GetNextValArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((DOC4003U00GetNextValArgs) obj);
    }

    public override int GetHashCode()
    {
        return  0;
    }

    public DOC4003U00GetNextValArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DOC4003U00GetNextValRequest();
        }
    }
}