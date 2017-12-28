using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class LoadPatientInfectionArgs : IContractArgs
    {
        private String _bunho;
        private String _hospCode;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public LoadPatientInfectionArgs() { }

        public LoadPatientInfectionArgs(String bunho, String hospCode)
        {
            this._bunho = bunho;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.LoadPatientInfectionRequest();
        }
    }
}