using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroPatientGridViewArgs : IContractArgs
    {
        protected bool Equals(NuroPatientGridViewArgs other)
        {
            return string.Equals(_patientCode, other._patientCode) && string.Equals(_comingDate, other._comingDate) && _changeComingDate.Equals(other._changeComingDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroPatientGridViewArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_patientCode != null ? _patientCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_comingDate != null ? _comingDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _changeComingDate.GetHashCode();
                return hashCode;
            }
        }

        private String _patientCode;
        private String _comingDate;
        private Boolean _changeComingDate;

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String ComingDate
        {
            get { return this._comingDate; }
            set { this._comingDate = value; }
        }

        public Boolean ChangeComingDate
        {
            get { return this._changeComingDate; }
            set { this._changeComingDate = value; }
        }

        public NuroPatientGridViewArgs() { }

        public NuroPatientGridViewArgs(String patientCode, String comingDate, Boolean changeComingDate)
        {
            this._patientCode = patientCode;
            this._comingDate = comingDate;
            this._changeComingDate = changeComingDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroPatientGridViewRequest();
        }
    }
}