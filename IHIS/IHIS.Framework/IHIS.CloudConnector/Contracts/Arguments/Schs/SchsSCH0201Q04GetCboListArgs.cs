using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{
    [Serializable]
	public class SchsSCH0201Q04GetCboListArgs : IContractArgs
	{
	    protected bool Equals(SchsSCH0201Q04GetCboListArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((SchsSCH0201Q04GetCboListArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public SchsSCH0201Q04GetCboListArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201Q04GetCboListRequest();
		}
	}
}