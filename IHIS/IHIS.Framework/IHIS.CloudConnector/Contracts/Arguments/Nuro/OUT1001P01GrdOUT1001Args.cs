using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class OUT1001P01GrdOUT1001Args : IContractArgs
	{
        protected bool Equals(OUT1001P01GrdOUT1001Args other)
        {
            return string.Equals(_naewonDate, other._naewonDate) && string.Equals(_bunho, other._bunho) && string.Equals(_pkout1001, other._pkout1001);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OUT1001P01GrdOUT1001Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _naewonDate;
		private String _bunho;
		private String _pkout1001;

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public OUT1001P01GrdOUT1001Args() { }

		public OUT1001P01GrdOUT1001Args(String naewonDate, String bunho, String pkout1001)
		{
			this._naewonDate = naewonDate;
			this._bunho = bunho;
			this._pkout1001 = pkout1001;
		}

		public IExtensible GetRequestInstance()
		{
			return new OUT1001P01GrdOUT1001Request();
		}
	}
}