using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
	public class ComboNaewonYnArgs : IContractArgs
	{
	    protected bool Equals(ComboNaewonYnArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((ComboNaewonYnArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public ComboNaewonYnArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new ComboNaewonYnRequest();
		}
	}
}