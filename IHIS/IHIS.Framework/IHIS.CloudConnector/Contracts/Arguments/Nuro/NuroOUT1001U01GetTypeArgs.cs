using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetTypeArgs : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01GetTypeArgs other)
        {
            return string.Equals(_naewonDate, other._naewonDate) && string.Equals(_bunho, other._bunho) && string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01GetTypeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _naewonDate;
        private String _bunho;
        private String _find1;

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

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public NuroOUT1001U01GetTypeArgs() { }

        public NuroOUT1001U01GetTypeArgs(String naewonDate, String bunho, String find1)
        {
            this._naewonDate = naewonDate;
            this._bunho = bunho;
            this._find1 = find1;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01GetTypeRequest();
        }
    }
}