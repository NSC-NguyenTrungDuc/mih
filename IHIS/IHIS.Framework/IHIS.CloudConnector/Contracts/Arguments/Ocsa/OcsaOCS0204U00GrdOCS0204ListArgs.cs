using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OcsaOCS0204U00GrdOCS0204ListArgs : IContractArgs
	{
    protected bool Equals(OcsaOCS0204U00GrdOCS0204ListArgs other)
    {
        return string.Equals(_fMemb, other._fMemb);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0204U00GrdOCS0204ListArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_fMemb != null ? _fMemb.GetHashCode() : 0);
    }

    private String _fMemb;

		public String FMemb
		{
			get { return this._fMemb; }
			set { this._fMemb = value; }
		}

		public OcsaOCS0204U00GrdOCS0204ListArgs() { }

		public OcsaOCS0204U00GrdOCS0204ListArgs(String fMemb)
		{
			this._fMemb = fMemb;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsaOCS0204U00GrdOCS0204ListRequest();
		}
	}
}