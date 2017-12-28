using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
	public class XRT0201U00LayConstantArgs : IContractArgs
	{
    protected bool Equals(XRT0201U00LayConstantArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0201U00LayConstantArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public XRT0201U00LayConstantArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new XRT0201U00LayConstantRequest();
		}
	}
}