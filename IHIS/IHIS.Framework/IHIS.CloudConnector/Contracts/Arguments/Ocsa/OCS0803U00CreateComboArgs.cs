using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0803U00CreateComboArgs : IContractArgs
    {
    protected bool Equals(OCS0803U00CreateComboArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0803U00CreateComboArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public OCS0803U00CreateComboArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0803U00CreateComboRequest();
        }
    }
}