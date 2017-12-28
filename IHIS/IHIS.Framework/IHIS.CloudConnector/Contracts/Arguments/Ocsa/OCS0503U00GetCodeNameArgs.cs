using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0503U00GetCodeNameArgs : IContractArgs
	{
    protected bool Equals(OCS0503U00GetCodeNameArgs other)
    {
        return string.Equals(_codeMode, other._codeMode) && string.Equals(_code, other._code);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503U00GetCodeNameArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_codeMode != null ? _codeMode.GetHashCode() : 0)*397) ^ (_code != null ? _code.GetHashCode() : 0);
        }
    }

    private String _codeMode;
		private String _code;

		public String CodeMode
		{
			get { return this._codeMode; }
			set { this._codeMode = value; }
		}

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public OCS0503U00GetCodeNameArgs() { }

		public OCS0503U00GetCodeNameArgs(String codeMode, String code)
		{
			this._codeMode = codeMode;
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503U00GetCodeNameRequest();
		}
	}
}