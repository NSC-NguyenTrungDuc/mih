using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OcsaOCS0221U00SeqArgs : IContractArgs
	{
    protected bool Equals(OcsaOCS0221U00SeqArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0221U00SeqArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public OcsaOCS0221U00SeqArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new OcsaOCS0221U00SeqRequest();
		}
	}
}