using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0113U00GetCodeNameArgs : IContractArgs
	{
    protected bool Equals(OCS0113U00GetCodeNameArgs other)
    {
        return string.Equals(_code, other._code);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0113U00GetCodeNameArgs) obj);
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

		public OCS0113U00GetCodeNameArgs() { }

		public OCS0113U00GetCodeNameArgs(String code)
		{
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0113U00GetCodeNameRequest();
		}
	}
}