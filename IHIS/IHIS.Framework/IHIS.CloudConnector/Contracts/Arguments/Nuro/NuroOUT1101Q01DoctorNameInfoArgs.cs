using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using System;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1101Q01DoctorNameInfoArgs : IContractArgs
    {
        protected bool Equals(NuroOUT1101Q01DoctorNameInfoArgs other)
        {
            return string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1101Q01DoctorNameInfoArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_gwa != null ? _gwa.GetHashCode() : 0)*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            }
        }

        public NuroOUT1101Q01DoctorNameInfoArgs() { }
    
        private string _gwa;

        public NuroOUT1101Q01DoctorNameInfoArgs(string gwa, string doctor)
        {
            _gwa = gwa;
            _doctor = doctor;
        }

        public string Gwa
        {
            get { return _gwa; }
            set { _gwa = value; }
        }
        private string _doctor;
        public string Doctor
        {
            get { return _doctor; }
            set { _doctor = value; }
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1101Q01DoctorNameInfoRequest();
        }
    }
}