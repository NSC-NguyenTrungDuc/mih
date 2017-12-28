using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class InjsINJ1001U01DetailListArgs : IContractArgs
	{
        protected bool Equals(InjsINJ1001U01DetailListArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_reserDate, other._reserDate) && string.Equals(_actingDate, other._actingDate) && string.Equals(_actingFlag, other._actingFlag);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InjsINJ1001U01DetailListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_actingDate != null ? _actingDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_actingFlag != null ? _actingFlag.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
		private String _gwa;
		private String _doctor;
		private String _reserDate;
		private String _actingDate;
		private String _actingFlag;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
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

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String ActingDate
		{
			get { return this._actingDate; }
			set { this._actingDate = value; }
		}

		public String ActingFlag
		{
			get { return this._actingFlag; }
			set { this._actingFlag = value; }
		}

		public InjsINJ1001U01DetailListArgs() { }

		public InjsINJ1001U01DetailListArgs(String bunho, String gwa, String doctor, String reserDate, String actingDate, String actingFlag)
		{
			this._bunho = bunho;
			this._gwa = gwa;
			this._doctor = doctor;
			this._reserDate = reserDate;
			this._actingDate = actingDate;
			this._actingFlag = actingFlag;
		}

		public IExtensible GetRequestInstance()
		{
			return new InjsINJ1001U01DetailListRequest();
		}
	}
}