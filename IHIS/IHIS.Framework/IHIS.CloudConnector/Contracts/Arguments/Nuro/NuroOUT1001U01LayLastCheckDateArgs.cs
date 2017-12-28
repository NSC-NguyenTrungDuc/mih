using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroOUT1001U01LayLastCheckDateArgs : IContractArgs
	{
        protected bool Equals(NuroOUT1001U01LayLastCheckDateArgs other)
        {
            return string.Equals(_gubun, other._gubun) && string.Equals(_bunho, other._bunho) && string.Equals(_date, other._date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01LayLastCheckDateArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_date != null ? _date.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _gubun;
		private String _bunho;
		private String _date;

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Date
		{
			get { return this._date; }
			set { this._date = value; }
		}

		public NuroOUT1001U01LayLastCheckDateArgs() { }

		public NuroOUT1001U01LayLastCheckDateArgs(String gubun, String bunho, String date)
		{
			this._gubun = gubun;
			this._bunho = bunho;
			this._date = date;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroOUT1001U01LayLastCheckDateRequest();
		}
	}
}