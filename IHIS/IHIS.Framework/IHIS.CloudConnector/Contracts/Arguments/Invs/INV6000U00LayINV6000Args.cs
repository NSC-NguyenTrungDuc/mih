using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV6000U00LayINV6000Args : IContractArgs
    {
        private String _hospCode;
        private String _month;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Month
        {
            get { return this._month; }
            set { this._month = value; }
        }

        public INV6000U00LayINV6000Args() { }

        public INV6000U00LayINV6000Args(String hospCode, String month)
        {
            this._hospCode = hospCode;
            this._month = month;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV6000U00LayINV6000Request();
        }
    }
}