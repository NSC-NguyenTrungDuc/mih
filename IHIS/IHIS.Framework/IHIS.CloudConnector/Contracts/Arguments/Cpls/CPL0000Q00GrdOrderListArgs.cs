using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    public class CPL0000Q00GrdOrderListArgs : IContractArgs
    {
        private String _hospCode;
        private String _bunho;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public CPL0000Q00GrdOrderListArgs() { }

        public CPL0000Q00GrdOrderListArgs(String hospCode, String bunho)
        {
            this._hospCode = hospCode;
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0000Q00GrdOrderListRequest();
        }
    }
}