using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NuriNUR1016U00ValidationDuplicateCheckArgs : IContractArgs
	{
        protected bool Equals(NuriNUR1016U00ValidationDuplicateCheckArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_allergyGubun, other._allergyGubun) && string.Equals(_startDate, other._startDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuriNUR1016U00ValidationDuplicateCheckArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_allergyGubun != null ? _allergyGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
		private String _allergyGubun;
		private String _startDate;

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

		public NuriNUR1016U00ValidationDuplicateCheckArgs() { }

		public NuriNUR1016U00ValidationDuplicateCheckArgs(String bunho, String allergyGubun, String startDate)
		{
			this._bunho = bunho;
			this._allergyGubun = allergyGubun;
			this._startDate = startDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuriNUR1016U00ValidationDuplicateCheckRequest();
		}
	}
}