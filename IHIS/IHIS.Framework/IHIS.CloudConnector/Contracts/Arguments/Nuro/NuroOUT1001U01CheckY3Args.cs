using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01CheckY3Args : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01CheckY3Args other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_jubsuNo, other._jubsuNo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01CheckY3Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuNo != null ? _jubsuNo.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
        private String _naewonDate;
        private String _jubsuNo;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String JubsuNo
        {
            get { return this._jubsuNo; }
            set { this._jubsuNo = value; }
        }

        public NuroOUT1001U01CheckY3Args() { }

        public NuroOUT1001U01CheckY3Args(String bunho, String naewonDate, String jubsuNo)
        {
            this._bunho = bunho;
            this._naewonDate = naewonDate;
            this._jubsuNo = jubsuNo;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01CheckY3Request();
        }
    }
}
