using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class OUT0101U02ChangePWDArgs : IContractArgs
    {
        private String _bunho;
        private String _pwd;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Pwd
        {
            get { return this._pwd; }
            set { this._pwd = value; }
        }

        public OUT0101U02ChangePWDArgs() { }

        public OUT0101U02ChangePWDArgs(String bunho, String pwd)
        {
            this._bunho = bunho;
            this._pwd = pwd;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUT0101U02ChangePWDRequest();
        }
    }
}