using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
	public class XRT0201U00CheckNaewonYnArgs : IContractArgs
	{
    protected bool Equals(XRT0201U00CheckNaewonYnArgs other)
    {
        return string.Equals(_pkout1001, other._pkout1001);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0201U00CheckNaewonYnArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
    }

    private String _pkout1001;

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public XRT0201U00CheckNaewonYnArgs() { }

		public XRT0201U00CheckNaewonYnArgs(String pkout1001)
		{
			this._pkout1001 = pkout1001;
		}

		public IExtensible GetRequestInstance()
		{
			return new XRT0201U00CheckNaewonYnRequest();
		}
	}
}