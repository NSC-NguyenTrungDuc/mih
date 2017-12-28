using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV2003U00CbxBuseoArgs : IContractArgs
    {
        private String _hospCode;
        private String _buseoCode;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String BuseoCode
        {
            get { return this._buseoCode; }
            set { this._buseoCode = value; }
        }

        public INV2003U00CbxBuseoArgs() { }

        public INV2003U00CbxBuseoArgs(String hospCode, String buseoCode)
        {
            this._hospCode = hospCode;
            this._buseoCode = buseoCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV2003U00CbxBuseoRequest();
        }
    }
}