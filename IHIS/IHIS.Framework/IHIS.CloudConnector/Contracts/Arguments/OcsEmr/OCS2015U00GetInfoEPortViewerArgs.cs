using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U00GetInfoEPortViewerArgs : IContractArgs
    {

        public OCS2015U00GetInfoEPortViewerArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U00GetInfoEPortViewerRequest();
        }
    }
}