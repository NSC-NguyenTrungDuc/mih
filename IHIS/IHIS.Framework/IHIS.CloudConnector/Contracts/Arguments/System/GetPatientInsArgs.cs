using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    public class GetPatientInsArgs : IContractArgs
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

        public GetPatientInsArgs() { }

        public GetPatientInsArgs(String patientCode, String hospCode)
        {
            this._patientCode = patientCode;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.GetPatientInsRequest();
        }
    }
}