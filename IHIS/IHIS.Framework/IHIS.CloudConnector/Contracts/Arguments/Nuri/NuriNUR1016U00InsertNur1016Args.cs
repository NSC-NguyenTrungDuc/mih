using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NuriNUR1016U00InsertNur1016Args : IContractArgs
	{
        protected bool Equals(NuriNUR1016U00InsertNur1016Args other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_pknur1016, other._pknur1016) && string.Equals(_bunho, other._bunho) && string.Equals(_allergyGubun, other._allergyGubun) && string.Equals(_allergyInfo, other._allergyInfo) && string.Equals(_startDate, other._startDate) && string.Equals(_endDate, other._endDate) && string.Equals(_endSayu, other._endSayu) && string.Equals(_inputText, other._inputText);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuriNUR1016U00InsertNur1016Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pknur1016 != null ? _pknur1016.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_allergyGubun != null ? _allergyGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_allergyInfo != null ? _allergyInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_endDate != null ? _endDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_endSayu != null ? _endSayu.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_inputText != null ? _inputText.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
		private String _pknur1016;
		private String _bunho;
		private String _allergyGubun;
		private String _allergyInfo;
		private String _startDate;
		private String _endDate;
		private String _endSayu;
		private String _inputText;

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

		public String AllergyInfo
		{
			get { return this._allergyInfo; }
			set { this._allergyInfo = value; }
		}

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public String EndDate
		{
			get { return this._endDate; }
			set { this._endDate = value; }
		}

		public String EndSayu
		{
			get { return this._endSayu; }
			set { this._endSayu = value; }
		}

		public String InputText
		{
			get { return this._inputText; }
			set { this._inputText = value; }
		}

		public NuriNUR1016U00InsertNur1016Args() { }

		public NuriNUR1016U00InsertNur1016Args(String userId, String pknur1016, String bunho, String allergyGubun, String allergyInfo, String startDate, String endDate, String endSayu, String inputText)
		{
			this._userId = userId;
			this._pknur1016 = pknur1016;
			this._bunho = bunho;
			this._allergyGubun = allergyGubun;
			this._allergyInfo = allergyInfo;
			this._startDate = startDate;
			this._endDate = endDate;
			this._endSayu = endSayu;
			this._inputText = inputText;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuriNUR1016U00InsertNur1016Request();
		}
	}
}