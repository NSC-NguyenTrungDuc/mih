using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NUR2001U04CboGwaArgs : IContractArgs
	{
	    protected bool Equals(NUR2001U04CboGwaArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((NUR2001U04CboGwaArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public NUR2001U04CboGwaArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new NUR2001U04CboGwaRequest();
		}
	}
}