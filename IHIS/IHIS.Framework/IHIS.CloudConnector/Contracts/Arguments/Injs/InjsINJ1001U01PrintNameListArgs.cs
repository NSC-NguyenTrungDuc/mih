using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class InjsINJ1001U01PrintNameListArgs : IContractArgs
	{
	    protected bool Equals(InjsINJ1001U01PrintNameListArgs other)
	    {
	        return string.Equals(_ipAddr, other._ipAddr);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((InjsINJ1001U01PrintNameListArgs) obj);
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

		public InjsINJ1001U01PrintNameListArgs() { }

		public InjsINJ1001U01PrintNameListArgs(String ipAddr)
		{
			this._ipAddr = ipAddr;
		}

		public IExtensible GetRequestInstance()
		{
			return new InjsINJ1001U01PrintNameListRequest();
		}
	}
}