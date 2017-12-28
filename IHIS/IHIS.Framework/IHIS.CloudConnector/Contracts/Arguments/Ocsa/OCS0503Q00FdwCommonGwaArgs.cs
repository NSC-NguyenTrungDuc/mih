using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    [Serializable]
	public class OCS0503Q00FdwCommonGwaArgs : IContractArgs
	{
	    protected bool Equals(OCS0503Q00FdwCommonGwaArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((OCS0503Q00FdwCommonGwaArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public OCS0503Q00FdwCommonGwaArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new OCS0503Q00FdwCommonGwaRequest();
		}
	}
}