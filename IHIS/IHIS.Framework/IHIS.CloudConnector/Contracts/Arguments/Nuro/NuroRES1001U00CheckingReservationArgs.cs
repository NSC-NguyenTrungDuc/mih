using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroRES1001U00CheckingReservationArgs : IContractArgs
	{
        protected bool Equals(NuroRES1001U00CheckingReservationArgs other)
        {
            return string.Equals(_doctorCode, other._doctorCode) && string.Equals(_examPreDate, other._examPreDate) && string.Equals(_examPreTime, other._examPreTime) && string.Equals(_inputType, other._inputType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00CheckingReservationArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_doctorCode != null ? _doctorCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreDate != null ? _examPreDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreTime != null ? _examPreTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_inputType != null ? _inputType.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _doctorCode;
		private String _examPreDate;
		private String _examPreTime;
		private String _inputType;

		public String DoctorCode
		{
			get { return this._doctorCode; }
			set { this._doctorCode = value; }
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

		public String InputType
		{
			get { return this._inputType; }
			set { this._inputType = value; }
		}

		public NuroRES1001U00CheckingReservationArgs() { }

		public NuroRES1001U00CheckingReservationArgs(String doctorCode, String examPreDate, String examPreTime, String inputType)
		{
			this._doctorCode = doctorCode;
			this._examPreDate = examPreDate;
			this._examPreTime = examPreTime;
			this._inputType = inputType;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroRES1001U00CheckingReservationRequest();
		}
	}
}