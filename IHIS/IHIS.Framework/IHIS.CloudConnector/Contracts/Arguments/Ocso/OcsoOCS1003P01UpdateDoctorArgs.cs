using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01UpdateDoctorArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01UpdateDoctorArgs other)
    {
        return string.Equals(_doctor, other._doctor) && string.Equals(_gwa, other._gwa) && string.Equals(_pkNaewon, other._pkNaewon);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01UpdateDoctorArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkNaewon != null ? _pkNaewon.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _doctor;
		private String _gwa;
		private String _pkNaewon;

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String PkNaewon
		{
			get { return this._pkNaewon; }
			set { this._pkNaewon = value; }
		}

		public OcsoOCS1003P01UpdateDoctorArgs() { }

		public OcsoOCS1003P01UpdateDoctorArgs(String doctor, String gwa, String pkNaewon)
		{
			this._doctor = doctor;
			this._gwa = gwa;
			this._pkNaewon = pkNaewon;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01UpdateDoctorRequest();
		}
	}
}