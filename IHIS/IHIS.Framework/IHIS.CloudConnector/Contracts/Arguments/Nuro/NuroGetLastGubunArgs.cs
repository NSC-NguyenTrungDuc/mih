using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroGetLastGubunArgs : IContractArgs
	{
        protected bool Equals(NuroGetLastGubunArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_naewonDate, other._naewonDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroGetLastGubunArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
		private String _gwa;
		private String _naewonDate;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public NuroGetLastGubunArgs() { }

		public NuroGetLastGubunArgs(String bunho, String gwa, String naewonDate)
		{
			this._bunho = bunho;
			this._gwa = gwa;
			this._naewonDate = naewonDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroGetLastGubunRequest();
		}
	}
}