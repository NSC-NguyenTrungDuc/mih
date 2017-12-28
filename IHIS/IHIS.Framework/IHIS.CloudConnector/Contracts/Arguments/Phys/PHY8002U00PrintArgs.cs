using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
	public class PHY8002U00PrintArgs : IContractArgs
	{
    protected bool Equals(PHY8002U00PrintArgs other)
    {
        return string.Equals(_gwa, other._gwa);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY8002U00PrintArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_gwa != null ? _gwa.GetHashCode() : 0);
    }

    private String _gwa;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public PHY8002U00PrintArgs() { }

		public PHY8002U00PrintArgs(String gwa)
		{
			this._gwa = gwa;
		}

		public IExtensible GetRequestInstance()
		{
			return new PHY8002U00PrintRequest();
		}
	}
}