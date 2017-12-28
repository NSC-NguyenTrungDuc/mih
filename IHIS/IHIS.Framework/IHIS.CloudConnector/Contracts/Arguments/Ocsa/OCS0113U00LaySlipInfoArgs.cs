using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0113U00LaySlipInfoArgs : IContractArgs
	{
    protected bool Equals(OCS0113U00LaySlipInfoArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0113U00LaySlipInfoArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public OCS0113U00LaySlipInfoArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new OCS0113U00LaySlipInfoRequest();
		}
	}
}