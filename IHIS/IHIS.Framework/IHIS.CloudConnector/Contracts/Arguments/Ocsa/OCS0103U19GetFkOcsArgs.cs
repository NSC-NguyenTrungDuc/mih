using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U19GetFkOcsArgs : IContractArgs
	{
    protected bool Equals(OCS0103U19GetFkOcsArgs other)
    {
        return string.Equals(_pkocskey, other._pkocskey);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U19GetFkOcsArgs) obj);
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

		public OCS0103U19GetFkOcsArgs() { }

		public OCS0103U19GetFkOcsArgs(String pkocskey)
		{
			this._pkocskey = pkocskey;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U19GetFkOcsRequest();
		}
	}
}