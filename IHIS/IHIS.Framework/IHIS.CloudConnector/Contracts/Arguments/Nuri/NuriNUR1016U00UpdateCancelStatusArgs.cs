using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NuriNUR1016U00UpdateCancelStatusArgs : IContractArgs
	{
        protected bool Equals(NuriNUR1016U00UpdateCancelStatusArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_pknur1016, other._pknur1016) && string.Equals(_bunho, other._bunho) && string.Equals(_allergyGubun, other._allergyGubun) && string.Equals(_startDate, other._startDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuriNUR1016U00UpdateCancelStatusArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pknur1016 != null ? _pknur1016.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_allergyGubun != null ? _allergyGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
		private String _pknur1016;
		private String _bunho;
		private String _allergyGubun;
		private String _startDate;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String Pknur1016
		{
			get { return this._pknur1016; }
			set { this._pknur1016 = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String AllergyGubun
		{
			get { return this._allergyGubun; }
			set { this._allergyGubun = value; }
		}

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public NuriNUR1016U00UpdateCancelStatusArgs() { }

		public NuriNUR1016U00UpdateCancelStatusArgs(String userId, String pknur1016, String bunho, String allergyGubun, String startDate)
		{
			this._userId = userId;
			this._pknur1016 = pknur1016;
			this._bunho = bunho;
			this._allergyGubun = allergyGubun;
			this._startDate = startDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuriNUR1016U00UpdateCancelStatusRequest();
		}
	}
}