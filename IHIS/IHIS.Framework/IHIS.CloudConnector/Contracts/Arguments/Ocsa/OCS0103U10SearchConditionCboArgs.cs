using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    [Serializable]
	public class OCS0103U10SearchConditionCboArgs : IContractArgs
	{
	    protected bool Equals(OCS0103U10SearchConditionCboArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((OCS0103U10SearchConditionCboArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public OCS0103U10SearchConditionCboArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U10SearchConditionCboRequest();
		}
	}
}