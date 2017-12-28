using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    public class OCS0103U00GetCommonYnArgs : IContractArgs
    {
        private List<DataStringListItemInfo> _hangmogList = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> HangmogList
        {
            get { return this._hangmogList; }
            set { this._hangmogList = value; }
        }

        public OCS0103U00GetCommonYnArgs() { }

        public OCS0103U00GetCommonYnArgs(List<DataStringListItemInfo> hangmogList)
        {
            this._hangmogList = hangmogList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00GetCommonYnRequest();
        }
    }
}