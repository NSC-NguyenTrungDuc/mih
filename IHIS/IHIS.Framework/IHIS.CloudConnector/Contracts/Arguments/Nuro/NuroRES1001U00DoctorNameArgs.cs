using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroRES1001U00DoctorNameArgs : IContractArgs
	{
        protected bool Equals(NuroRES1001U00DoctorNameArgs other)
        {
            return string.Equals(_patientCode, other._patientCode) && string.Equals(_departmentCode, other._departmentCode) && string.Equals(_examPreDate, other._examPreDate) && string.Equals(_examPreTime, other._examPreTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00DoctorNameArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_patientCode != null ? _patientCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_departmentCode != null ? _departmentCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreDate != null ? _examPreDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreTime != null ? _examPreTime.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _patientCode;
		private String _departmentCode;
		private String _examPreDate;
		private String _examPreTime;

		public String PatientCode
		{
			get { return this._patientCode; }
			set { this._patientCode = value; }
		}

		public String DepartmentCode
		{
			get { return this._departmentCode; }
			set { this._departmentCode = value; }
		}

		public String ExamPreDate
		{
			get { return this._examPreDate; }
			set { this._examPreDate = value; }
		}

		public String ExamPreTime
		{
			get { return this._examPreTime; }
			set { this._examPreTime = value; }
		}

		public NuroRES1001U00DoctorNameArgs() { }

		public NuroRES1001U00DoctorNameArgs(String patientCode, String departmentCode, String examPreDate, String examPreTime)
		{
			this._patientCode = patientCode;
			this._departmentCode = departmentCode;
			this._examPreDate = examPreDate;
			this._examPreTime = examPreTime;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroRES1001U00DoctorNameRequest();
		}
	}
}