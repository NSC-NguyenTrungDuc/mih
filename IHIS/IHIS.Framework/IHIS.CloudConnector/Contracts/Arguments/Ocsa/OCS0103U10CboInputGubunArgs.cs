using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    [Serializable]
	public class OCS0103U10CboInputGubunArgs : IContractArgs
	{
	    protected bool Equals(OCS0103U10CboInputGubunArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((OCS0103U10CboInputGubunArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public OCS0103U10CboInputGubunArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U10CboInputGubunRequest();
		}
	}
}