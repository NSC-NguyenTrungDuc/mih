using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    public class ADM108UGrdListArgs : IContractArgs
    {
        private String _sysId;
        private String _hospCode;

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public ADM108UGrdListArgs() { }

        public ADM108UGrdListArgs(String sysId, String hospCode)
        {
            this._sysId = sysId;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM108UGrdListRequest();
        }
    }
}