using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroCheckBookingArgs : IContractArgs
    {
        protected bool Equals(NuroCheckBookingArgs other)
        {
            return string.Equals(_patientCode, other._patientCode) && string.Equals(_reserDate, other._reserDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroCheckBookingArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_patientCode != null ? _patientCode.GetHashCode() : 0)*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
            }
        }

        private String _patientCode;
        private String _reserDate;

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public NuroCheckBookingArgs() { }

        public NuroCheckBookingArgs(String patientCode, String reserDate)
        {
            this._patientCode = patientCode;
            this._reserDate = reserDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroCheckBookingRequest();
        }
    }
}
