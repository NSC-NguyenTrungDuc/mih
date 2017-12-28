using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ1001U01GrdOCS1003Args : IContractArgs
	{
        protected bool Equals(INJ1001U01GrdOCS1003Args other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_language, other._language) && string.Equals(_bunho, other._bunho) && string.Equals(_startDate, other._startDate) && string.Equals(_endDate, other._endDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1001U01GrdOCS1003Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_language != null ? _language.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_endDate != null ? _endDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
		private String _language;
		private String _bunho;
		private String _startDate;
		private String _endDate;

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public String Language
		{
			get { return this._language; }
			set { this._language = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
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

		public INJ1001U01GrdOCS1003Args() { }

		public INJ1001U01GrdOCS1003Args(String hospCode, String language, String bunho, String startDate, String endDate)
		{
			this._hospCode = hospCode;
			this._language = language;
			this._bunho = bunho;
			this._startDate = startDate;
			this._endDate = endDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ1001U01GrdOCS1003Request();
		}
	}
}