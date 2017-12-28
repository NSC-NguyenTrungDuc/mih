using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SchsSCH0201U99GrdTimeListArgs : IContractArgs
    {
    protected bool Equals(SchsSCH0201U99GrdTimeListArgs other)
    {
        return string.Equals(_ipAddr, other._ipAddr) && string.Equals(_outHospcode, other._outHospcode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201U99GrdTimeListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_ipAddr != null ? _ipAddr.GetHashCode() : 0)*397) ^ (_outHospcode != null ? _outHospcode.GetHashCode() : 0);
        }
    }

    private String _ipAddr;
        private String _outHospcode;

        public String IpAddr
        {
            get { return this._ipAddr; }
            set { this._ipAddr = value; }
        }

        public String OutHospcode
        {
            get { return this._outHospcode; }
            set { this._outHospcode = value; }
        }

        public SchsSCH0201U99GrdTimeListArgs() { }

        public SchsSCH0201U99GrdTimeListArgs(String ipAddr, String outHospcode)
        {
            this._ipAddr = ipAddr;
            this._outHospcode = outHospcode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SchsSCH0201U99GrdTimeListRequest();
        }
    }
}