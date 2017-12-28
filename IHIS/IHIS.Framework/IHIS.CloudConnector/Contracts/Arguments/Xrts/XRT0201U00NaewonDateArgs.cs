using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
	public class XRT0201U00NaewonDateArgs : IContractArgs
	{
    protected bool Equals(XRT0201U00NaewonDateArgs other)
    {
        return string.Equals(_naewonKey, other._naewonKey);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0201U00NaewonDateArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_naewonKey != null ? _naewonKey.GetHashCode() : 0);
    }

    private String _naewonKey;

		public String NaewonKey
		{
			get { return this._naewonKey; }
			set { this._naewonKey = value; }
		}

		public XRT0201U00NaewonDateArgs() { }

		public XRT0201U00NaewonDateArgs(String naewonKey)
		{
			this._naewonKey = naewonKey;
		}

		public IExtensible GetRequestInstance()
		{
			return new XRT0201U00NaewonDateRequest();
		}
	}
}