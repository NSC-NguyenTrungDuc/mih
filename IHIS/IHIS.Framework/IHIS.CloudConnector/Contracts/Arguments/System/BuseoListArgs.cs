using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
	public class BuseoListArgs : IContractArgs
	{
	    protected bool Equals(BuseoListArgs other)
	    {
	        return string.Equals(_buseoGubun, other._buseoGubun);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((BuseoListArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return (_buseoGubun != null ? _buseoGubun.GetHashCode() : 0);
	    }

	    private String _buseoGubun;

		public String BuseoGubun
		{
			get { return this._buseoGubun; }
			set { this._buseoGubun = value; }
		}

		public BuseoListArgs() { }

		public BuseoListArgs(String buseoGubun)
		{
			this._buseoGubun = buseoGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new BuseoListRequest();
		}
	}
}