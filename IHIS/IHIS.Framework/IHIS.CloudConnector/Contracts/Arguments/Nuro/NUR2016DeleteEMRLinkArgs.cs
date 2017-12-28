using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class NUR2016DeleteEMRLinkArgs : IContractArgs
    {
        private String _patientId;

        public String PatientId
        {
            get { return this._patientId; }
            set { this._patientId = value; }
        }

        public NUR2016DeleteEMRLinkArgs() { }

        public NUR2016DeleteEMRLinkArgs(String patientId)
        {
            this._patientId = patientId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2016DeleteEMRLinkRequest();
        }
    }
}