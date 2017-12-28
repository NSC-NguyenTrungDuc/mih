using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01BasLoadGwaNameArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01BasLoadGwaNameArgs other)
    {
        return string.Equals(_gwa, other._gwa) && string.Equals(_buseoYmd, other._buseoYmd);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01BasLoadGwaNameArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_gwa != null ? _gwa.GetHashCode() : 0)*397) ^ (_buseoYmd != null ? _buseoYmd.GetHashCode() : 0);
        }
    }

    private String _gwa;
		private String _buseoYmd;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String BuseoYmd
		{
			get { return this._buseoYmd; }
			set { this._buseoYmd = value; }
		}

		public OcsoOCS1003P01BasLoadGwaNameArgs() { }

		public OcsoOCS1003P01BasLoadGwaNameArgs(String gwa, String buseoYmd)
		{
			this._gwa = gwa;
			this._buseoYmd = buseoYmd;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01BasLoadGwaNameRequest();
		}
	}
}