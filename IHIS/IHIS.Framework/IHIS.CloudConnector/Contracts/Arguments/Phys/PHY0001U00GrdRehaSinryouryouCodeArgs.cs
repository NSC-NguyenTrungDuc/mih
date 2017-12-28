using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
	public class PHY0001U00GrdRehaSinryouryouCodeArgs : IContractArgs
	{
    protected bool Equals(PHY0001U00GrdRehaSinryouryouCodeArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY0001U00GrdRehaSinryouryouCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public PHY0001U00GrdRehaSinryouryouCodeArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new PHY0001U00GrdRehaSinryouryouCodeRequest();
		}
	}
}