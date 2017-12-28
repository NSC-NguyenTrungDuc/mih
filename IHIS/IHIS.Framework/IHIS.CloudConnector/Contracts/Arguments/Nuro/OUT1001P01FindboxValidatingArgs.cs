using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class OUT1001P01FindboxValidatingArgs : IContractArgs
	{
        protected bool Equals(OUT1001P01FindboxValidatingArgs other)
        {
            return string.Equals(_startDate, other._startDate) && string.Equals(_find1, other._find1) && string.Equals(_gwa, other._gwa) && string.Equals(_controlName, other._controlName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OUT1001P01FindboxValidatingArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_startDate != null ? _startDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_controlName != null ? _controlName.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _startDate;
		private String _find1;
		private String _gwa;
		private String _controlName;

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String ControlName
		{
			get { return this._controlName; }
			set { this._controlName = value; }
		}

		public OUT1001P01FindboxValidatingArgs() { }

		public OUT1001P01FindboxValidatingArgs(String startDate, String find1, String gwa, String controlName)
		{
			this._startDate = startDate;
			this._find1 = find1;
			this._gwa = gwa;
			this._controlName = controlName;
		}

		public IExtensible GetRequestInstance()
		{
			return new OUT1001P01FindboxValidatingRequest();
		}
	}
}