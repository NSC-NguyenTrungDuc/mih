using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class NUR2015U01GrdOrderArgs : IContractArgs
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

        public NUR2015U01GrdOrderArgs() { }

        public NUR2015U01GrdOrderArgs(String bunho, String hospCode)
        {
            this._bunho = bunho;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2015U01GrdOrderRequest();
        }
    }
}