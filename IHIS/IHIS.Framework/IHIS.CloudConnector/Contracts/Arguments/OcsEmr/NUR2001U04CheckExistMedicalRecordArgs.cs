using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    [Serializable]
    public class NUR2001U04CheckExistMedicalRecordArgs : IContractArgs
    {
        private String _patientCode;

        protected bool Equals(NUR2001U04CheckExistMedicalRecordArgs other)
        {
            return string.Equals(_patientCode, other._patientCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR2001U04CheckExistMedicalRecordArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_patientCode != null ? _patientCode.GetHashCode() : 0);
        }

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public NUR2001U04CheckExistMedicalRecordArgs() { }

        public NUR2001U04CheckExistMedicalRecordArgs(String patientCode)
        {
            this._patientCode = patientCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2001U04CheckExistMedicalRecordRequest();
        }
    }
}