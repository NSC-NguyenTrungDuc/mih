using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroRES1001U00ReceptionNumberArgs : IContractArgs
	{
        protected bool Equals(NuroRES1001U00ReceptionNumberArgs other)
        {
            return string.Equals(_patientCode, other._patientCode) && string.Equals(_examPreDate, other._examPreDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00ReceptionNumberArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_patientCode != null ? _patientCode.GetHashCode() : 0)*397) ^ (_examPreDate != null ? _examPreDate.GetHashCode() : 0);
            }
        }

        private String _patientCode;
		private String _examPreDate;

		public String PatientCode
		{
			get { return this._patientCode; }
			set { this._patientCode = value; }
		}

		public String ExamPreDate
		{
			get { return this._examPreDate; }
			set { this._examPreDate = value; }
		}

		public NuroRES1001U00ReceptionNumberArgs() { }

		public NuroRES1001U00ReceptionNumberArgs(String patientCode, String examPreDate)
		{
			this._patientCode = patientCode;
			this._examPreDate = examPreDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroRES1001U00ReceptionNumberRequest();
		}
	}
}