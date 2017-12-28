using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0801U00GrdOCS0801Args : IContractArgs
    {
    protected bool Equals(OCS0801U00GrdOCS0801Args other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0801U00GrdOCS0801Args) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public OCS0801U00GrdOCS0801Args() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0801U00GrdOCS0801Request();
        }
    }
}