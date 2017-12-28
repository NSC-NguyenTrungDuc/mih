using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OcsaOCS0204U00SangGubunNameArgs : IContractArgs
	{
    protected bool Equals(OcsaOCS0204U00SangGubunNameArgs other)
    {
        return string.Equals(_memb, other._memb) && string.Equals(_code, other._code);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0204U00SangGubunNameArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_memb != null ? _memb.GetHashCode() : 0)*397) ^ (_code != null ? _code.GetHashCode() : 0);
        }
    }

    private String _memb;
		private String _code;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public OcsaOCS0204U00SangGubunNameArgs() { }

		public OcsaOCS0204U00SangGubunNameArgs(String memb, String code)
		{
			this._memb = memb;
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsaOCS0204U00SangGubunNameRequest();
		}
	}
}