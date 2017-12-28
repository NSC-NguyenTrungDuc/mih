using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
	public class ComboGwaArgs : IContractArgs
	{
	    protected bool Equals(ComboGwaArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((ComboGwaArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public IExtensible GetRequestInstance()
		{
			return new ComboGwaRequest();
		}
	}
}