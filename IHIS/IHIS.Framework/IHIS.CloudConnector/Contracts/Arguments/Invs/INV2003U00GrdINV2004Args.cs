using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV2003U00GrdINV2004Args : IContractArgs
    {
        private String _hospCode;
        private String _fkinv2003;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Fkinv2003
        {
            get { return this._fkinv2003; }
            set { this._fkinv2003 = value; }
        }

        public INV2003U00GrdINV2004Args() { }

        public INV2003U00GrdINV2004Args(String hospCode, String fkinv2003)
        {
            this._hospCode = hospCode;
            this._fkinv2003 = fkinv2003;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV2003U00GrdINV2004Request();
        }
    }
}