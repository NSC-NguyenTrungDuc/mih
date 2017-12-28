using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U00GetOrderByPkoutArgs : IContractArgs
    {
        private String _bunho;
        private String _pkout;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Pkout
        {
            get { return this._pkout; }
            set { this._pkout = value; }
        }

        public OCS2015U00GetOrderByPkoutArgs() { }

        public OCS2015U00GetOrderByPkoutArgs(String bunho, String pkout)
        {
            this._bunho = bunho;
            this._pkout = pkout;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U00GetOrderByPkoutRequest();
        }
    }
}