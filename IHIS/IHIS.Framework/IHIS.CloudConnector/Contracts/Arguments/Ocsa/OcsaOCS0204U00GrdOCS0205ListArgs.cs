using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OcsaOCS0204U00GrdOCS0205ListArgs : IContractArgs
	{
    protected bool Equals(OcsaOCS0204U00GrdOCS0205ListArgs other)
    {
        return string.Equals(_fMemb, other._fMemb) && string.Equals(_sangGubun, other._sangGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0204U00GrdOCS0205ListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_fMemb != null ? _fMemb.GetHashCode() : 0)*397) ^ (_sangGubun != null ? _sangGubun.GetHashCode() : 0);
        }
    }

    private String _fMemb;
		private String _sangGubun;

		public String FMemb
		{
			get { return this._fMemb; }
			set { this._fMemb = value; }
		}

		public String SangGubun
		{
			get { return this._sangGubun; }
			set { this._sangGubun = value; }
		}

		public OcsaOCS0204U00GrdOCS0205ListArgs() { }

		public OcsaOCS0204U00GrdOCS0205ListArgs(String fMemb, String sangGubun)
		{
			this._fMemb = fMemb;
			this._sangGubun = sangGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsaOCS0204U00GrdOCS0205ListRequest();
		}
	}
}