using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1101Q01FwkDoctorArgs : IContractArgs
    {
        protected bool Equals(NuroOUT1101Q01FwkDoctorArgs other)
        {
            return string.Equals(_find1, other._find1) && string.Equals(_gwa, other._gwa);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1101Q01FwkDoctorArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_find1 != null ? _find1.GetHashCode() : 0)*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            }
        }

        private string _find1;
        private string _gwa;

        public NuroOUT1101Q01FwkDoctorArgs(string find1, string gwa)
        {
            _find1 = find1;
            _gwa = gwa;
        }

        public string Gwa
        {
            get { return _gwa; }
            set { _gwa = value; }
        }

        public string Find1
        {
            get { return _find1; }
            set { _find1 = value; }
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1101Q01FwkDoctorRequest();
        }
    }
}