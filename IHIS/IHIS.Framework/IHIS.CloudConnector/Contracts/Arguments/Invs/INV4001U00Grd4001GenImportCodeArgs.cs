using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV4001U00Grd4001GenImportCodeArgs : IContractArgs
    {

        public INV4001U00Grd4001GenImportCodeArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV4001U00Grd4001GenImportCodeRequest();
        }
    }
}