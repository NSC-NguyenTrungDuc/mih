using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    public class GetPatientByCodeArgs : IContractArgs
    {
        private String _patientCode;
        private String _hospCode;

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public GetPatientByCodeArgs() { }

        public GetPatientByCodeArgs(String patientCode, String hospCode)
        {
            this._patientCode = patientCode;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.GetPatientByCodeRequest();
        }
        protected bool Equals(GetPatientByCodeArgs other)
        {
            return string.Equals(_patientCode, other._patientCode) && string.Equals(_hospCode, other._hospCode);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GetPatientByCodeArgs)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((_patientCode != null ? _patientCode.GetHashCode() : 0) * 397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            }
        }
    }
}