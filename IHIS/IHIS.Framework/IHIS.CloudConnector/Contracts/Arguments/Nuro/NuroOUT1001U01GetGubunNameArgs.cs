using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetGubunNameArgs : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01GetGubunNameArgs other)
        {
            return string.Equals(_gubun, other._gubun) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01GetGubunNameArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _gubun;
        private String _naewonDate;
        private String _bunho;

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

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

        public NuroOUT1001U01GetGubunNameArgs() { }

        public NuroOUT1001U01GetGubunNameArgs(String gubun, String naewonDate, String bunho)
        {
            this._gubun = gubun;
            this._naewonDate = naewonDate;
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01GetGubunNameRequest();
        }
    }
}