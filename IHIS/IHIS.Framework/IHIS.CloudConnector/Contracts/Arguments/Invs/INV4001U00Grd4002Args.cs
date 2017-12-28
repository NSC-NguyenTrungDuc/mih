using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV4001U00Grd4002Args : IContractArgs
    {
        private String _fFkinv4001;

        public String FFkinv4001
        {
            get { return this._fFkinv4001; }
            set { this._fFkinv4001 = value; }
        }

        public INV4001U00Grd4002Args() { }

        public INV4001U00Grd4002Args(String fFkinv4001)
        {
            this._fFkinv4001 = fFkinv4001;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV4001U00Grd4002Request();
        }
    }
}