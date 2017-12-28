using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroOut1001U01CheckDoctorScheduleArgs : IContractArgs
	{
        protected bool Equals(NuroOut1001U01CheckDoctorScheduleArgs other)
        {
            return string.Equals(_type, other._type) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_jubsuTime, other._jubsuTime) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOut1001U01CheckDoctorScheduleArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_type != null ? _type.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuTime != null ? _jubsuTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _type;
		private String _naewonDate;
		private String _jubsuTime;
		private String _gwa;
		private String _doctor;

		public String Type
		{
			get { return this._type; }
			set { this._type = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String JubsuTime
		{
			get { return this._jubsuTime; }
			set { this._jubsuTime = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public NuroOut1001U01CheckDoctorScheduleArgs() { }

		public NuroOut1001U01CheckDoctorScheduleArgs(String type, String naewonDate, String jubsuTime, String gwa, String doctor)
		{
			this._type = type;
			this._naewonDate = naewonDate;
			this._jubsuTime = jubsuTime;
			this._gwa = gwa;
			this._doctor = doctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroOut1001U01CheckDoctorScheduleRequest();
		}
	}
}