using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroRES1001U00ReservationOut1001UpdateArgs : IContractArgs
	{
        protected bool Equals(NuroRES1001U00ReservationOut1001UpdateArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_examPreDate, other._examPreDate) && string.Equals(_examPreTime, other._examPreTime) && string.Equals(_receptionNo, other._receptionNo) && string.Equals(_pkout1001, other._pkout1001);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00ReservationOut1001UpdateArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreDate != null ? _examPreDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreTime != null ? _examPreTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_receptionNo != null ? _receptionNo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
		private String _examPreDate;
		private String _examPreTime;
		private String _receptionNo;
		private String _pkout1001;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
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

		public String ReceptionNo
		{
			get { return this._receptionNo; }
			set { this._receptionNo = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public NuroRES1001U00ReservationOut1001UpdateArgs() { }

		public NuroRES1001U00ReservationOut1001UpdateArgs(String userId, String examPreDate, String examPreTime, String receptionNo, String pkout1001)
		{
			this._userId = userId;
			this._examPreDate = examPreDate;
			this._examPreTime = examPreTime;
			this._receptionNo = receptionNo;
			this._pkout1001 = pkout1001;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroRES1001U00ReservationOut1001UpdateRequest();
		}
	}
}