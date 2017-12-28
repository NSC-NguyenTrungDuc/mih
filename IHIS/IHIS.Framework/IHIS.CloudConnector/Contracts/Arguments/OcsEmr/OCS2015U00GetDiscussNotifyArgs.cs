using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsemr
{[Serializable]
    public class OCS2015U00GetDiscussNotifyArgs : IContractArgs
    {
    protected bool Equals(OCS2015U00GetDiscussNotifyArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U00GetDiscussNotifyArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public OCS2015U00GetDiscussNotifyArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U00GetDiscussNotifyRequest();
        }
    }
}