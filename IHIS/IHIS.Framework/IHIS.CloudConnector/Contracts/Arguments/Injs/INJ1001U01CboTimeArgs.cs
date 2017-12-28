using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
   [Serializable]
	public class INJ1001U01CboTimeArgs : IContractArgs
	{
	    protected bool Equals(INJ1001U01CboTimeArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((INJ1001U01CboTimeArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public INJ1001U01CboTimeArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new INJ1001U01CboTimeRequest();
		}
	}
}