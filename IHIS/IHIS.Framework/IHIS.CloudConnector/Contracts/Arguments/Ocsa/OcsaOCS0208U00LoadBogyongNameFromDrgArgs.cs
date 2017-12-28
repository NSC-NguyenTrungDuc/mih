using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OcsaOCS0208U00LoadBogyongNameFromDrgArgs : IContractArgs
	{
    protected bool Equals(OcsaOCS0208U00LoadBogyongNameFromDrgArgs other)
    {
        return string.Equals(_code, other._code);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0208U00LoadBogyongNameFromDrgArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_code != null ? _code.GetHashCode() : 0);
    }

    private String _code;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public OcsaOCS0208U00LoadBogyongNameFromDrgArgs() { }

		public OcsaOCS0208U00LoadBogyongNameFromDrgArgs(String code)
		{
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsaOCS0208U00LoadBogyongNameFromDrgRequest();
		}
	}
}