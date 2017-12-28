using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
	public class ComboPayArgs : IContractArgs
	{
	    protected bool Equals(ComboPayArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((ComboPayArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public ComboPayArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new ComboPayRequest();
		}
	}
}