using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
public class NuroOut1101Q01GridInfoArgs : IContractArgs
    {
        protected bool Equals(NuroOut1101Q01GridInfoArgs other)
        {
            return string.Equals(_doctor, other._doctor) && string.Equals(_gwa, other._gwa) && string.Equals(_naewonDate, other._naewonDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOut1101Q01GridInfoArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private string _doctor;
        private string _gwa;
        private string _naewonDate;

        public NuroOut1101Q01GridInfoArgs()
        {
        }

        public NuroOut1101Q01GridInfoArgs(string doctor, string gwa, string naewonDate)
        {
            _doctor = doctor;
            _gwa = gwa;
            _naewonDate = naewonDate;
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

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1101Q01GridInfoRequest();
        }
    }
}