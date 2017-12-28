using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
    public class OCS2015U31EmrTemplateTypeArgs : IContractArgs
    {
    protected bool Equals(OCS2015U31EmrTemplateTypeArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U31EmrTemplateTypeArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public OCS2015U31EmrTemplateTypeArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U31EmrTemplateTypeRequest();
        }
    }
}