using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroGetDoctorNameBAS0270Args : IContractArgs
	{
        protected bool Equals(NuroGetDoctorNameBAS0270Args other)
        {
            return string.Equals(_doctor, other._doctor) && string.Equals(_gwa, other._gwa) && string.Equals(_naewonDate, other._naewonDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroGetDoctorNameBAS0270Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _doctor;
		private String _gwa;
		private String _naewonDate;

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

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public NuroGetDoctorNameBAS0270Args() { }

		public NuroGetDoctorNameBAS0270Args(String doctor, String gwa, String naewonDate)
		{
			this._doctor = doctor;
			this._gwa = gwa;
			this._naewonDate = naewonDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroGetDoctorNameBAS0270Request();
		}
	}
}