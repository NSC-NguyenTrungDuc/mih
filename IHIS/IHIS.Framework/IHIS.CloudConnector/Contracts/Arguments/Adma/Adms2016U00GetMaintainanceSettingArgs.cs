using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    public class Adms2016U00GetMaintainanceSettingArgs : IContractArgs
    {

        public Adms2016U00GetMaintainanceSettingArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Adms2016U00GetMaintainanceSettingRequest();
        }
    }
}