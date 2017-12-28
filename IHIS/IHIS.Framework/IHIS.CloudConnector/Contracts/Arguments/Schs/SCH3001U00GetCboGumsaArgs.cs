using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{
    [Serializable]
	public class SCH3001U00GetCboGumsaArgs : IContractArgs
	{
	    protected bool Equals(SCH3001U00GetCboGumsaArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((SCH3001U00GetCboGumsaArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public SCH3001U00GetCboGumsaArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new SCH3001U00GetCboGumsaRequest();
		}
	}
}