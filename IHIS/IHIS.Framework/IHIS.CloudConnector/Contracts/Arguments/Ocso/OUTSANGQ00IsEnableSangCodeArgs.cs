using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OUTSANGQ00IsEnableSangCodeArgs : IContractArgs
    {
    protected bool Equals(OUTSANGQ00IsEnableSangCodeArgs other)
    {
        return string.Equals(_pkoutsang, other._pkoutsang) && string.Equals(_bunho, other._bunho);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUTSANGQ00IsEnableSangCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_pkoutsang != null ? _pkoutsang.GetHashCode() : 0)*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
        }
    }

    private String _pkoutsang;
        private String _bunho;

        public String Pkoutsang
        {
            get { return this._pkoutsang; }
            set { this._pkoutsang = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public OUTSANGQ00IsEnableSangCodeArgs() { }

        public OUTSANGQ00IsEnableSangCodeArgs(String pkoutsang, String bunho)
        {
            this._pkoutsang = pkoutsang;
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUTSANGQ00IsEnableSangCodeRequest();
        }
    }
}