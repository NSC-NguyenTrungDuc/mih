using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0204Q00GrdOCS0205Args : IContractArgs
	{
    protected bool Equals(OCS0204Q00GrdOCS0205Args other)
    {
        return string.Equals(_memb, other._memb) && string.Equals(_sangGubun, other._sangGubun) && string.Equals(_sangNameInx, other._sangNameInx);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0204Q00GrdOCS0205Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_memb != null ? _memb.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sangGubun != null ? _sangGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sangNameInx != null ? _sangNameInx.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _memb;
		private String _sangGubun;
		private String _sangNameInx;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String SangGubun
		{
			get { return this._sangGubun; }
			set { this._sangGubun = value; }
		}

		public String SangNameInx
		{
			get { return this._sangNameInx; }
			set { this._sangNameInx = value; }
		}

		public OCS0204Q00GrdOCS0205Args() { }

		public OCS0204Q00GrdOCS0205Args(String memb, String sangGubun, String sangNameInx)
		{
			this._memb = memb;
			this._sangGubun = sangGubun;
			this._sangNameInx = sangNameInx;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0204Q00GrdOCS0205Request();
		}
	}
}