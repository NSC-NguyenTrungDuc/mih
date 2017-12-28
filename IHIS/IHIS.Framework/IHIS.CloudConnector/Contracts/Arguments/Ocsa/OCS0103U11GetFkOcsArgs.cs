using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U11GetFkocsArgs : IContractArgs
	{
    protected bool Equals(OCS0103U11GetFkocsArgs other)
    {
        return string.Equals(_pkocskey, other._pkocskey);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U11GetFkocsArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_pkocskey != null ? _pkocskey.GetHashCode() : 0);
    }

    private String _pkocskey;

		public String Pkocskey
		{
			get { return this._pkocskey; }
			set { this._pkocskey = value; }
		}

		public OCS0103U11GetFkocsArgs() { }

		public OCS0103U11GetFkocsArgs(String pkocskey)
		{
			this._pkocskey = pkocskey;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U11GetFkocsRequest();
		}
	}
}