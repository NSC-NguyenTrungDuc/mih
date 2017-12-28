using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U00EmrDownloadFileRimindArgs : IContractArgs
    {

        public OCS2015U00EmrDownloadFileRimindArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U00EmrDownloadFileRimindRequest();
        }
    }
}