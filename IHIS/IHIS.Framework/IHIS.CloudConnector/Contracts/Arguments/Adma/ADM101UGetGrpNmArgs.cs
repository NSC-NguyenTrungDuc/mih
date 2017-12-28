using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{[Serializable]
	public class ADM101UGetGrpNmArgs : IContractArgs
	{
    protected bool Equals(ADM101UGetGrpNmArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ADM101UGetGrpNmArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public ADM101UGetGrpNmArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new ADM101UGetGrpNmRequest();
		}
	}
}