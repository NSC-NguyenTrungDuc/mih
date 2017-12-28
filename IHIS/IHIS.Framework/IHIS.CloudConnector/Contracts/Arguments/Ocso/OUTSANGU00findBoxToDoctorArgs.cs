using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OUTSANGU00findBoxToDoctorArgs : IContractArgs
	{
    protected bool Equals(OUTSANGU00findBoxToDoctorArgs other)
    {
        return string.Equals(_gwa, other._gwa) && string.Equals(_find1, other._find1) && string.Equals(_doctorYmd, other._doctorYmd);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUTSANGU00findBoxToDoctorArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctorYmd != null ? _doctorYmd.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _gwa;
		private String _find1;
		private String _doctorYmd;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public String DoctorYmd
		{
			get { return this._doctorYmd; }
			set { this._doctorYmd = value; }
		}

		public OUTSANGU00findBoxToDoctorArgs() { }

		public OUTSANGU00findBoxToDoctorArgs(String gwa, String find1, String doctorYmd)
		{
			this._gwa = gwa;
			this._find1 = find1;
			this._doctorYmd = doctorYmd;
		}

		public IExtensible GetRequestInstance()
		{
			return new OUTSANGU00findBoxToDoctorRequest();
		}
	}
}