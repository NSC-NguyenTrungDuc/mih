using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    public class CPL3020U02ImportFileArgs : IContractArgs
    {
        private String _jangbiCode;

        public String JangbiCode
        {
            get { return this._jangbiCode; }
            set { this._jangbiCode = value; }
        }

        public CPL3020U02ImportFileArgs() { }

        public CPL3020U02ImportFileArgs(String jangbiCode)
        {
            this._jangbiCode = jangbiCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3020U02ImportFileRequest();
        }
    }
}