using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
	public class ComboNur0101Args : IContractArgs
	{
	    protected bool Equals(ComboNur0101Args other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((ComboNur0101Args) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public ComboNur0101Args() { }

		public IExtensible GetRequestInstance()
		{
			return new ComboNur0101Request();
		}
	}
}