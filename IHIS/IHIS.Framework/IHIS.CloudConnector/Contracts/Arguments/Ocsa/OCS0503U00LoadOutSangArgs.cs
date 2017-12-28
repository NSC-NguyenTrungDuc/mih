using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0503U00LoadOutSangArgs : IContractArgs
	{
    protected bool Equals(OCS0503U00LoadOutSangArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_ioGubun, other._ioGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503U00LoadOutSangArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
		private String _gwa;
		private String _ioGubun;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public OCS0503U00LoadOutSangArgs() { }

		public OCS0503U00LoadOutSangArgs(String bunho, String gwa, String ioGubun)
		{
			this._bunho = bunho;
			this._gwa = gwa;
			this._ioGubun = ioGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503U00LoadOutSangRequest();
		}
	}
}