using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTLayconstantAlarmArgs : IContractArgs
    {
    protected bool Equals(OCSACTLayconstantAlarmArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSACTLayconstantAlarmArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public OCSACTLayconstantAlarmArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTLayconstantAlarmRequest();
        }
    }
}