using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroManagePatientArgs : IContractArgs
    {
        protected bool Equals(NuroManagePatientArgs other)
        {
            return string.Equals(_patientCode, other._patientCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroManagePatientArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_patientCode != null ? _patientCode.GetHashCode() : 0);
        }

        public string _patientCode;

        public NuroManagePatientArgs()
        {
        }

        public NuroManagePatientArgs(string patientCode)
        {
            _patientCode = patientCode;
        }

        public string PatientCode
        {
            get { return _patientCode; }
            set { _patientCode = value; }
        }

        public IExtensible GetRequestInstance()
        {
            return  new NuroManagePatientRequest();
        }
    }
}
