using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103Q00LoadKatakanaFullArgs : IContractArgs
	{
    protected bool Equals(OCS0103Q00LoadKatakanaFullArgs other)
    {
        return string.Equals(_text, other._text);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103Q00LoadKatakanaFullArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_text != null ? _text.GetHashCode() : 0);
    }

    private String _text;

		public String Text
		{
			get { return this._text; }
			set { this._text = value; }
		}

		public OCS0103Q00LoadKatakanaFullArgs() { }

		public OCS0103Q00LoadKatakanaFullArgs(String text)
		{
			this._text = text;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103Q00LoadKatakanaFullRequest();
		}
	}
}