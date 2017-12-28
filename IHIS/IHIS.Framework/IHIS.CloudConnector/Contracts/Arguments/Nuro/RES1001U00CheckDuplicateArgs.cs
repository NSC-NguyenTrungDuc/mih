using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class RES1001U00CheckDuplicateArgs : IContractArgs
    {
        private List<RES1001U00SaveLayoutItemInfo> _inputInfo = new List<RES1001U00SaveLayoutItemInfo>();
        private String _hospCodeLink;

        public List<RES1001U00SaveLayoutItemInfo> InputInfo
        {
            get { return this._inputInfo; }
            set { this._inputInfo = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public RES1001U00CheckDuplicateArgs() { }

        public RES1001U00CheckDuplicateArgs(List<RES1001U00SaveLayoutItemInfo> inputInfo, String hospCodeLink)
        {
            this._inputInfo = inputInfo;
            this._hospCodeLink = hospCodeLink;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.RES1001U00CheckDuplicateRequest();
        }
    }
}