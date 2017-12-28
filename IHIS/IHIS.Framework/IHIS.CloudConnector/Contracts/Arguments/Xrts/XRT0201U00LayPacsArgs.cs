using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
	public class XRT0201U00LayPacsArgs : IContractArgs
	{
    protected bool Equals(XRT0201U00LayPacsArgs other)
    {
        return string.Equals(_hangmogCode, other._hangmogCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0201U00LayPacsArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
    }

    private String _hangmogCode;

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public XRT0201U00LayPacsArgs() { }

		public XRT0201U00LayPacsArgs(String hangmogCode)
		{
			this._hangmogCode = hangmogCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new XRT0201U00LayPacsRequest();
		}
	}
}