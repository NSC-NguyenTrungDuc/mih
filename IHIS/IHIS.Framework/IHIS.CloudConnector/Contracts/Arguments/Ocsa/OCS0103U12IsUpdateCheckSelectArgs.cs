using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U12IsUpdateCheckSelectArgs : IContractArgs
	{
    protected bool Equals(OCS0103U12IsUpdateCheckSelectArgs other)
    {
        return string.Equals(_pkocs2003, other._pkocs2003);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U12IsUpdateCheckSelectArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_pkocs2003 != null ? _pkocs2003.GetHashCode() : 0);
    }

    private String _pkocs2003;

		public String Pkocs2003
		{
			get { return this._pkocs2003; }
			set { this._pkocs2003 = value; }
		}

		public OCS0103U12IsUpdateCheckSelectArgs() { }

		public OCS0103U12IsUpdateCheckSelectArgs(String pkocs2003)
		{
			this._pkocs2003 = pkocs2003;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U12IsUpdateCheckSelectRequest();
		}
	}
}