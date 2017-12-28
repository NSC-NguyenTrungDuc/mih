using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetDoctorArgs : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01GetDoctorArgs other)
        {
            return string.Equals(_naewonDate, other._naewonDate) && string.Equals(_gwa, other._gwa) && string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01GetDoctorArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _naewonDate;
        private String _gwa;
        private String _find1;

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public NuroOUT1001U01GetDoctorArgs() { }

        public NuroOUT1001U01GetDoctorArgs(String naewonDate, String gwa, String find1)
        {
            this._naewonDate = naewonDate;
            this._gwa = gwa;
            this._find1 = find1;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01GetDoctorRequest();
        }
    }
}