using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class OUT0101U02ImportPatientArgs : IContractArgs
    {
        private List<OUT0101U02ImportPatientInfo> _patients = new List<OUT0101U02ImportPatientInfo>();
        private String _userId;
        private Boolean _ignoreDuplicate;

        public List<OUT0101U02ImportPatientInfo> Patients
        {
            get { return this._patients; }
            set { this._patients = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public Boolean IgnoreDuplicate
        {
            get { return this._ignoreDuplicate; }
            set { this._ignoreDuplicate = value; }
        }

        public OUT0101U02ImportPatientArgs() { }

        public OUT0101U02ImportPatientArgs(List<OUT0101U02ImportPatientInfo> patients, String userId, Boolean ignoreDuplicate)
        {
            this._patients = patients;
            this._userId = userId;
            this._ignoreDuplicate = ignoreDuplicate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUT0101U02ImportPatientRequest();
        }
    }
}