using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U12LayDrugTreeArgs : IContractArgs
	{
    protected bool Equals(OCS0103U12LayDrugTreeArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U12LayDrugTreeArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public OCS0103U12LayDrugTreeArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U12LayDrugTreeRequest();
		}
	}
}