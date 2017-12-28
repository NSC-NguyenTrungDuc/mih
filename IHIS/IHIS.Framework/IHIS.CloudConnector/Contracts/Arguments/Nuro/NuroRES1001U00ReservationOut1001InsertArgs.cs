using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroRES1001U00ReservationOut1001InsertArgs : IContractArgs
	{
        protected bool Equals(NuroRES1001U00ReservationOut1001InsertArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_pkout1001, other._pkout1001) && string.Equals(_examPreDate, other._examPreDate) && string.Equals(_patientCode, other._patientCode) && string.Equals(_departmentCode, other._departmentCode) && string.Equals(_type, other._type) && string.Equals(_doctorCode, other._doctorCode) && string.Equals(_changgu, other._changgu) && string.Equals(_examPreTime, other._examPreTime) && string.Equals(_examStatus, other._examStatus) && string.Equals(_reserType, other._reserType) && string.Equals(_receptionNo, other._receptionNo) && string.Equals(_inputType, other._inputType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00ReservationOut1001InsertArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreDate != null ? _examPreDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_patientCode != null ? _patientCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_departmentCode != null ? _departmentCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_type != null ? _type.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctorCode != null ? _doctorCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_changgu != null ? _changgu.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreTime != null ? _examPreTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examStatus != null ? _examStatus.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserType != null ? _reserType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_receptionNo != null ? _receptionNo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_inputType != null ? _inputType.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
		private String _pkout1001;
		private String _examPreDate;
		private String _patientCode;
		private String _departmentCode;
		private String _type;
		private String _doctorCode;
		private String _changgu;
		private String _examPreTime;
		private String _examStatus;
		private String _reserType;
		private String _receptionNo;
		private String _inputType;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public String ExamPreDate
		{
			get { return this._examPreDate; }
			set { this._examPreDate = value; }
		}

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

		public String Type
		{
			get { return this._type; }
			set { this._type = value; }
		}

		public String DoctorCode
		{
			get { return this._doctorCode; }
			set { this._doctorCode = value; }
		}

		public String Changgu
		{
			get { return this._changgu; }
			set { this._changgu = value; }
		}

		public String ExamPreTime
		{
			get { return this._examPreTime; }
			set { this._examPreTime = value; }
		}

		public String ExamStatus
		{
			get { return this._examStatus; }
			set { this._examStatus = value; }
		}

		public String ReserType
		{
			get { return this._reserType; }
			set { this._reserType = value; }
		}

		public String ReceptionNo
		{
			get { return this._receptionNo; }
			set { this._receptionNo = value; }
		}

		public String InputType
		{
			get { return this._inputType; }
			set { this._inputType = value; }
		}

		public NuroRES1001U00ReservationOut1001InsertArgs() { }

		public NuroRES1001U00ReservationOut1001InsertArgs(String userId, String pkout1001, String examPreDate, String patientCode, String departmentCode, String type, String doctorCode, String changgu, String examPreTime, String examStatus, String reserType, String receptionNo, String inputType)
		{
			this._userId = userId;
			this._pkout1001 = pkout1001;
			this._examPreDate = examPreDate;
			this._patientCode = patientCode;
			this._departmentCode = departmentCode;
			this._type = type;
			this._doctorCode = doctorCode;
			this._changgu = changgu;
			this._examPreTime = examPreTime;
			this._examStatus = examStatus;
			this._reserType = reserType;
			this._receptionNo = receptionNo;
			this._inputType = inputType;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroRES1001U00ReservationOut1001InsertRequest();
		}
	}
}