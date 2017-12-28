using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class NUR2016U02TranferArgs : IContractArgs
    {
        private List<NUR2016U02TranferInfo> _listItem = new List<NUR2016U02TranferInfo>();

        public List<NUR2016U02TranferInfo> ListItem
        {
            get { return this._listItem; }
            set { this._listItem = value; }
        }

        public NUR2016U02TranferArgs() { }

        public NUR2016U02TranferArgs(List<NUR2016U02TranferInfo> listItem)
        {
            this._listItem = listItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2016U02TranferRequest();
        }
    }
}