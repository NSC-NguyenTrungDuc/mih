using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04CboGwaArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04CboGwaArgs other)
    {
        return string.Equals(_buseoYmd, other._buseoYmd);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04CboGwaArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_buseoYmd != null ? _buseoYmd.GetHashCode() : 0);
    }

    private String _buseoYmd;

        public String BuseoYmd
        {
            get { return this._buseoYmd; }
            set { this._buseoYmd = value; }
        }

        public PHY2001U04CboGwaArgs() { }

        public PHY2001U04CboGwaArgs(String buseoYmd)
        {
            this._buseoYmd = buseoYmd;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04CboGwaRequest();
        }
    }
}