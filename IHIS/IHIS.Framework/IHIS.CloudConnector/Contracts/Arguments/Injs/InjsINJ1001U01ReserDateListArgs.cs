using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class InjsINJ1001U01ReserDateListArgs : IContractArgs
	{
        protected bool Equals(InjsINJ1001U01ReserDateListArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_doctor, other._doctor) && string.Equals(_actingFlag, other._actingFlag) && string.Equals(_reserDate, other._reserDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InjsINJ1001U01ReserDateListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_actingFlag != null ? _actingFlag.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
		private String _doctor;
		private String _actingFlag;
		private String _reserDate;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String ActingFlag
		{
			get { return this._actingFlag; }
			set { this._actingFlag = value; }
		}

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public InjsINJ1001U01ReserDateListArgs() { }

		public InjsINJ1001U01ReserDateListArgs(String bunho, String doctor, String actingFlag, String reserDate)
		{
			this._bunho = bunho;
			this._doctor = doctor;
			this._actingFlag = actingFlag;
			this._reserDate = reserDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new InjsINJ1001U01ReserDateListRequest();
		}
	}
}