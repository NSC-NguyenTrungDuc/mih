using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class InjsINJ1001U01TempListArgs : IContractArgs
	{
        protected bool Equals(InjsINJ1001U01TempListArgs other)
        {
            return string.Equals(_jubsuDate, other._jubsuDate) && string.Equals(_bunho, other._bunho) && string.Equals(_doctor, other._doctor) && string.Equals(_reserDate, other._reserDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InjsINJ1001U01TempListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_jubsuDate != null ? _jubsuDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _jubsuDate;
		private String _bunho;
		private String _doctor;
		private String _reserDate;

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
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

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public InjsINJ1001U01TempListArgs() { }

		public InjsINJ1001U01TempListArgs(String jubsuDate, String bunho, String doctor, String reserDate)
		{
			this._jubsuDate = jubsuDate;
			this._bunho = bunho;
			this._doctor = doctor;
			this._reserDate = reserDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new InjsINJ1001U01TempListRequest();
		}
	}
}