using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class CheckHospUseMovieTalkArgs : IContractArgs
    {

        public CheckHospUseMovieTalkArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CheckHospUseMovieTalkRequest();
        }
    }
}