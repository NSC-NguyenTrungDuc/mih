using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0304U00GrdOCS0305Args : IContractArgs
	{
    protected bool Equals(OCS0304U00GrdOCS0305Args other)
    {
        return string.Equals(_doctor, other._doctor) && string.Equals(_membGubun, other._membGubun) && string.Equals(_yaksokDirectCode, other._yaksokDirectCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0304U00GrdOCS0305Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_membGubun != null ? _membGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_yaksokDirectCode != null ? _yaksokDirectCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _doctor;
		private String _membGubun;
		private String _yaksokDirectCode;

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String MembGubun
		{
			get { return this._membGubun; }
			set { this._membGubun = value; }
		}

		public String YaksokDirectCode
		{
			get { return this._yaksokDirectCode; }
			set { this._yaksokDirectCode = value; }
		}

		public OCS0304U00GrdOCS0305Args() { }

		public OCS0304U00GrdOCS0305Args(String doctor, String membGubun, String yaksokDirectCode)
		{
			this._doctor = doctor;
			this._membGubun = membGubun;
			this._yaksokDirectCode = yaksokDirectCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0304U00GrdOCS0305Request();
		}
	}
}