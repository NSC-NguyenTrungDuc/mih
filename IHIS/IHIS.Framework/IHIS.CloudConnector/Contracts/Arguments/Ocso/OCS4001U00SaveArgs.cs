using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    public class OCS4001U00SaveArgs : IContractArgs
    {
        private List<OCS4001U00SaveInfo> _items = new List<OCS4001U00SaveInfo>();

        public List<OCS4001U00SaveInfo> Items
        {
            get { return this._items; }
            set { this._items = value; }
        }

        public OCS4001U00SaveArgs() { }

        public OCS4001U00SaveArgs(List<OCS4001U00SaveInfo> items)
        {
            this._items = items;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS4001U00SaveRequest();
        }
    }
}