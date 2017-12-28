using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OcsaOCS0221U00CommonDataArgs : IContractArgs
    {
    protected bool Equals(OcsaOCS0221U00CommonDataArgs other)
    {
        return string.Equals(_memb, other._memb) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0221U00CommonDataArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_memb != null ? _memb.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }
    }

    private String _memb;
        private String _hospCode;

        public String Memb
        {
            get { return this._memb; }
            set { this._memb = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OcsaOCS0221U00CommonDataArgs() { }

        public OcsaOCS0221U00CommonDataArgs(String memb, String hospCode)
        {
            this._memb = memb;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OcsaOCS0221U00CommonDataRequest();
        }
    }
}