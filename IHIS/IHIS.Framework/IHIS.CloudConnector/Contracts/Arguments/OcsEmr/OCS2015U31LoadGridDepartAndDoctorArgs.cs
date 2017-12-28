using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U31LoadGridDepartAndDoctorArgs : IContractArgs
    {

        public OCS2015U31LoadGridDepartAndDoctorArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U31LoadGridDepartAndDoctorRequest();
        }
    }
}