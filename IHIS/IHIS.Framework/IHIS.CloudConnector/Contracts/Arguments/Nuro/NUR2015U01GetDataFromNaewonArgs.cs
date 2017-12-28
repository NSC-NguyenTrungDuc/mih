using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class NUR2015U01GetDataFromNaewonArgs : IContractArgs
    {
        private String _naewonKey;

        public String NaewonKey
        {
            get { return this._naewonKey; }
            set { this._naewonKey = value; }
        }

        public NUR2015U01GetDataFromNaewonArgs() { }

        public NUR2015U01GetDataFromNaewonArgs(String naewonKey)
        {
            this._naewonKey = naewonKey;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2015U01GetDataFromNaewonRequest();
        }
    }
}