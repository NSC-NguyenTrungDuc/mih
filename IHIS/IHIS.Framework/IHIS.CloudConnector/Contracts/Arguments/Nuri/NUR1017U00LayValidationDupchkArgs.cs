using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NUR1017U00LayValidationDupchkArgs : IContractArgs
	{
        protected bool Equals(NUR1017U00LayValidationDupchkArgs other)
        {
            return string.Equals(_infeCode, other._infeCode) && string.Equals(_bunho, other._bunho) && string.Equals(_startDate, other._startDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR1017U00LayValidationDupchkArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_infeCode != null ? _infeCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _infeCode;
		private String _bunho;
		private String _startDate;

		public String InfeCode
		{
			get { return this._infeCode; }
			set { this._infeCode = value; }
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

		public NUR1017U00LayValidationDupchkArgs() { }

		public NUR1017U00LayValidationDupchkArgs(String infeCode, String bunho, String startDate)
		{
			this._infeCode = infeCode;
			this._bunho = bunho;
			this._startDate = startDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUR1017U00LayValidationDupchkRequest();
		}
	}
}