using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00ScreenOpenUpdateArgs : IContractArgs
	{
        protected bool Equals(CPL0000Q00ScreenOpenUpdateArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_doctor, other._doctor) && string.Equals(_bunho, other._bunho) && string.Equals(_jundalTable, other._jundalTable);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00ScreenOpenUpdateArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
		private String _doctor;
		private String _bunho;
		private String _jundalTable;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String JundalTable
		{
			get { return this._jundalTable; }
			set { this._jundalTable = value; }
		}

		public CPL0000Q00ScreenOpenUpdateArgs() { }

		public CPL0000Q00ScreenOpenUpdateArgs(String userId, String doctor, String bunho, String jundalTable)
		{
			this._userId = userId;
			this._doctor = doctor;
			this._bunho = bunho;
			this._jundalTable = jundalTable;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00ScreenOpenUpdateRequest();
		}
	}
}