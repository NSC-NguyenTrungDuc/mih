using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV6000U00ExportCSVArgs : IContractArgs
    {
        private String _month;

        public String Month
        {
            get { return this._month; }
            set { this._month = value; }
        }

        public INV6000U00ExportCSVArgs() { }

        public INV6000U00ExportCSVArgs(String month)
        {
            this._month = month;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV6000U00ExportCSVRequest();
        }
    }
}