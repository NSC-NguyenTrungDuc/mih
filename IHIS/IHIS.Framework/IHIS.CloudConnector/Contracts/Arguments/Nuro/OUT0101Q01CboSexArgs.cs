using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class OUT0101Q01CboSexArgs : IContractArgs
	{
	    protected bool Equals(OUT0101Q01CboSexArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((OUT0101Q01CboSexArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public OUT0101Q01CboSexArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new OUT0101Q01CboSexRequest();
		}
	}
}