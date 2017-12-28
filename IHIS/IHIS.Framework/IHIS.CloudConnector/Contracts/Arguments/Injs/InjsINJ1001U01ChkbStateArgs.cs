using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class InjsINJ1001U01ChkbStateArgs : IContractArgs
	{
        protected bool Equals(InjsINJ1001U01ChkbStateArgs other)
        {
            return string.Equals(_reserDate, other._reserDate) && string.Equals(_actingFlag, other._actingFlag) && string.Equals(_bunho, other._bunho) && string.Equals(_doctor, other._doctor);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InjsINJ1001U01ChkbStateArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_reserDate != null ? _reserDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_actingFlag != null ? _actingFlag.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _reserDate;
		private String _actingFlag;
		private String _bunho;
		private String _doctor;

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String ActingFlag
		{
			get { return this._actingFlag; }
			set { this._actingFlag = value; }
		}

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

		public InjsINJ1001U01ChkbStateArgs() { }

		public InjsINJ1001U01ChkbStateArgs(String reserDate, String actingFlag, String bunho, String doctor)
		{
			this._reserDate = reserDate;
			this._actingFlag = actingFlag;
			this._bunho = bunho;
			this._doctor = doctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new InjsINJ1001U01ChkbStateRequest();
		}
	}
}