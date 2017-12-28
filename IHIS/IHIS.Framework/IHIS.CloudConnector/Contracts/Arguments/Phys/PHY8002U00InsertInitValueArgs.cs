using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
	public class PHY8002U00InsertInitValueArgs : IContractArgs
	{
    protected bool Equals(PHY8002U00InsertInitValueArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY8002U00InsertInitValueArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public PHY8002U00InsertInitValueArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new PHY8002U00InsertInitValueRequest();
		}
	}
}