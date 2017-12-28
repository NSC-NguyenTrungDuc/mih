using System;
using IHIS.CloudConnector.Contracts.Models.INVS;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.INVS
{
    public class INV6002U00GrdINV6002ExcuteArgs : IContractArgs
    {
        private List<INV6002U00GrdINV6002ExcuteInfo> _item = new List<INV6002U00GrdINV6002ExcuteInfo>();

        public List<INV6002U00GrdINV6002ExcuteInfo> Item
        {
            get { return this._item; }
            set { this._item = value; }
        }

        public INV6002U00GrdINV6002ExcuteArgs() { }

        public INV6002U00GrdINV6002ExcuteArgs(List<INV6002U00GrdINV6002ExcuteInfo> item)
        {
            this._item = item;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV6002U00GrdINV6002ExcuteRequest();
        }
    }
}