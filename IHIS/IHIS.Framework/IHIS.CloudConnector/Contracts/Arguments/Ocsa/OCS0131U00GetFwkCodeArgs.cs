using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0131U00GetFwkCodeArgs : IContractArgs
	{
    protected bool Equals(OCS0131U00GetFwkCodeArgs other)
    {
        return string.Equals(_find1, other._find1);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0131U00GetFwkCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_find1 != null ? _find1.GetHashCode() : 0);
    }

    private String _find1;

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public OCS0131U00GetFwkCodeArgs() { }

		public OCS0131U00GetFwkCodeArgs(String find1)
		{
			this._find1 = find1;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0131U00GetFwkCodeRequest();
		}
	}
}