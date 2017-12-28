using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
	public class PHY0001U00GrdOCS0132Args : IContractArgs
	{
    protected bool Equals(PHY0001U00GrdOCS0132Args other)
    {
        return string.Equals(_codeType, other._codeType);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY0001U00GrdOCS0132Args) obj);
    }

    public override int GetHashCode()
    {
        return (_codeType != null ? _codeType.GetHashCode() : 0);
    }

    private String _codeType;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public PHY0001U00GrdOCS0132Args() { }

		public PHY0001U00GrdOCS0132Args(String codeType)
		{
			this._codeType = codeType;
		}

		public IExtensible GetRequestInstance()
		{
			return new PHY0001U00GrdOCS0132Request();
		}
	}
}