using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    public class DRG0120U00GrdNaebogArgs : IContractArgs
    {
        private String _hospCode;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public DRG0120U00GrdNaebogArgs() { }

        public DRG0120U00GrdNaebogArgs(String hospCode)
        {
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DRG0120U00GrdNaebogRequest();
        }
    }
}