using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class AbleInsteadOrderArgs : IContractArgs
    {
        private AbleInsteadOrderInfo _info1;

        public AbleInsteadOrderInfo Info1
        {
            get { return this._info1; }
            set { this._info1 = value; }
        }

        public AbleInsteadOrderArgs() { }

        public AbleInsteadOrderArgs(AbleInsteadOrderInfo info1)
        {
            this._info1 = info1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.AbleInsteadOrderRequest();
        }
    }
}