using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroPatientDetailListArgs : IContractArgs
    {
        protected bool Equals(NuroPatientDetailListArgs other)
        {
            return string.Equals(_patientCode, other._patientCode) && string.Equals(_comingDate, other._comingDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroPatientDetailListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_patientCode != null ? _patientCode.GetHashCode() : 0)*397) ^ (_comingDate != null ? _comingDate.GetHashCode() : 0);
            }
        }

        private String _patientCode;
        private String _comingDate;

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

        public NuroPatientDetailListArgs() { }

        public NuroPatientDetailListArgs(String patientCode, String comingDate)
        {
            this._patientCode = patientCode;
            this._comingDate = comingDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroPatientDetailListRequest();
        }
    }

}
