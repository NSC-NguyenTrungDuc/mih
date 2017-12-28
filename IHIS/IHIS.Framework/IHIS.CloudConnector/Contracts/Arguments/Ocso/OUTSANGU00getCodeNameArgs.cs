using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OUTSANGU00getCodeNameArgs : IContractArgs
	{
    protected bool Equals(OUTSANGU00getCodeNameArgs other)
    {
        return string.Equals(_code, other._code) && string.Equals(_sangEndSayU, other._sangEndSayU);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUTSANGU00getCodeNameArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_code != null ? _code.GetHashCode() : 0)*397) ^ (_sangEndSayU != null ? _sangEndSayU.GetHashCode() : 0);
        }
    }

    private String _code;
		private String _sangEndSayU;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String SangEndSayU
		{
			get { return this._sangEndSayU; }
			set { this._sangEndSayU = value; }
		}

		public OUTSANGU00getCodeNameArgs() { }

		public OUTSANGU00getCodeNameArgs(String code, String sangEndSayU)
		{
			this._code = code;
			this._sangEndSayU = sangEndSayU;
		}

		public IExtensible GetRequestInstance()
		{
			return new OUTSANGU00getCodeNameRequest();
		}
	}
}