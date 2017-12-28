using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH3001U00LayDupOCS0103Args : IContractArgs
	{
    protected bool Equals(SCH3001U00LayDupOCS0103Args other)
    {
        return string.Equals(_jundalPart, other._jundalPart);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH3001U00LayDupOCS0103Args) obj);
    }

    public override int GetHashCode()
    {
        return (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
    }

    private String _jundalPart;

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public SCH3001U00LayDupOCS0103Args() { }

		public SCH3001U00LayDupOCS0103Args(String jundalPart)
		{
			this._jundalPart = jundalPart;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH3001U00LayDupOCS0103Request();
		}
	}
}