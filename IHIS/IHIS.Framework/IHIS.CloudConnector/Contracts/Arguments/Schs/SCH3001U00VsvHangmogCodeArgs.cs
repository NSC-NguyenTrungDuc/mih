using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH3001U00VsvHangmogCodeArgs : IContractArgs
	{
    protected bool Equals(SCH3001U00VsvHangmogCodeArgs other)
    {
        return string.Equals(_code, other._code);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH3001U00VsvHangmogCodeArgs) obj);
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

		public SCH3001U00VsvHangmogCodeArgs() { }

		public SCH3001U00VsvHangmogCodeArgs(String code)
		{
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH3001U00VsvHangmogCodeRequest();
		}
	}
}