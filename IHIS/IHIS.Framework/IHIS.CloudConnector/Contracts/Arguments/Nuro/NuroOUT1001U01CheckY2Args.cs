using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01CheckY2Args : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01CheckY2Args other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_naewonType, other._naewonType) && string.Equals(_jubsuNo, other._jubsuNo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01CheckY2Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonType != null ? _naewonType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuNo != null ? _jubsuNo.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
        private String _naewonDate;
        private String _gwa;
        private String _doctor;
        private String _naewonType;
        private String _jubsuNo;

        public NuroOUT1001U01CheckY2Args(string bunho, string naewonDate, string gwa, string doctor, string naewonType, string jubsuNo)
        {
            _bunho = bunho;
            _naewonDate = naewonDate;
            _gwa = gwa;
            _doctor = doctor;
            _naewonType = naewonType;
            _jubsuNo = jubsuNo;
        }

        public NuroOUT1001U01CheckY2Args()
        {
        }

        public string Bunho
        {
            get { return _bunho; }
            set { _bunho = value; }
        }

        public string NaewonDate
        {
            get { return _naewonDate; }
            set { _naewonDate = value; }
        }

        public string Gwa
        {
            get { return _gwa; }
            set { _gwa = value; }
        }

        public string Doctor
        {
            get { return _doctor; }
            set { _doctor = value; }
        }

        public string NaewonType
        {
            get { return _naewonType; }
            set { _naewonType = value; }
        }

        public string JubsuNo
        {
            get { return _jubsuNo; }
            set { _jubsuNo = value; }
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01CheckY2Request();
        }
    }
}
