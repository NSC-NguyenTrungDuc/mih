using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SCH0201U10GrdReserListArgs : IContractArgs
    {
    protected bool Equals(SCH0201U10GrdReserListArgs other)
    {
        return string.Equals(_bunho, other._bunho);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0201U10GrdReserListArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_bunho != null ? _bunho.GetHashCode() : 0);
    }

    private String _bunho;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public SCH0201U10GrdReserListArgs() { }

        public SCH0201U10GrdReserListArgs(String bunho)
        {
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SCH0201U10GrdReserListRequest();
        }
    }
}