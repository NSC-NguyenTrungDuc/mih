using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class NUR2016PublishEMRLinkArgs : IContractArgs
    {
        private String _patientId;
        private Boolean _ischeck;

        public String PatientId
        {
            get { return this._patientId; }
            set { this._patientId = value; }
        }

        public Boolean Ischeck
        {
            get { return this._ischeck; }
            set { this._ischeck = value; }
        }

        public NUR2016PublishEMRLinkArgs() { }

        public NUR2016PublishEMRLinkArgs(String patientId, Boolean ischeck)
        {
            this._patientId = patientId;
            this._ischeck = ischeck;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2016PublishEMRLinkRequest();
        }
    }
}