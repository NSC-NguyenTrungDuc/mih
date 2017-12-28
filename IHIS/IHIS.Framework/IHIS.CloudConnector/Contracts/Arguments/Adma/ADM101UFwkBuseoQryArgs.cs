using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{ [Serializable]
	public class ADM101UFwkBuseoQryArgs : IContractArgs
	{
    protected bool Equals(ADM101UFwkBuseoQryArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ADM101UFwkBuseoQryArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public ADM101UFwkBuseoQryArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new ADM101UFwkBuseoQryRequest();
		}
	}
}