using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
	public class ComboPortableYnArgs : IContractArgs
	{
	    protected bool Equals(ComboPortableYnArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((ComboPortableYnArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public ComboPortableYnArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new ComboPortableYnRequest();
		}
	}
}