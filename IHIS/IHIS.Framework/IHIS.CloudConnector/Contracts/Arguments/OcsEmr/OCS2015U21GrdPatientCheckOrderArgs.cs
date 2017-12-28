using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U21GrdPatientCheckOrderArgs : IContractArgs
    {
        private String _fkout1001;

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public OCS2015U21GrdPatientCheckOrderArgs() { }

        public OCS2015U21GrdPatientCheckOrderArgs(String fkout1001)
        {
            this._fkout1001 = fkout1001;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U21GrdPatientCheckOrderRequest();
        }
    }
}