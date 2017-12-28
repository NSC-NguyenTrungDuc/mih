using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201Q04ReserTimeListArgs : IContractArgs
	{
    protected bool Equals(SchsSCH0201Q04ReserTimeListArgs other)
    {
        return string.Equals(_ipAddr, other._ipAddr);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201Q04ReserTimeListArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_ipAddr != null ? _ipAddr.GetHashCode() : 0);
    }

    private String _ipAddr;

		public String IpAddr
		{
			get { return this._ipAddr; }
			set { this._ipAddr = value; }
		}

		public SchsSCH0201Q04ReserTimeListArgs() { }

		public SchsSCH0201Q04ReserTimeListArgs(String ipAddr)
		{
			this._ipAddr = ipAddr;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201Q04ReserTimeListRequest();
		}
	}
}