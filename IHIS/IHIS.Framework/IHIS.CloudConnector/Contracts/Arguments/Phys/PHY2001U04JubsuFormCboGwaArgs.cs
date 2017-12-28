using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04JubsuFormCboGwaArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04JubsuFormCboGwaArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04JubsuFormCboGwaArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public PHY2001U04JubsuFormCboGwaArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04JubsuFormCboGwaRequest();
        }
    }
}