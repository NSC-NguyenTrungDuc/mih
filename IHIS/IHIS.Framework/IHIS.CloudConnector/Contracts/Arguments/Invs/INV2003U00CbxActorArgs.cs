using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV2003U00CbxActorArgs : IContractArgs
    {
        private String _hospCode;
        private String _userGroup;
        private String _userEndYmd;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String UserGroup
        {
            get { return this._userGroup; }
            set { this._userGroup = value; }
        }

        public String UserEndYmd
        {
            get { return this._userEndYmd; }
            set { this._userEndYmd = value; }
        }

        public INV2003U00CbxActorArgs() { }

        public INV2003U00CbxActorArgs(String hospCode, String userGroup, String userEndYmd)
        {
            this._hospCode = hospCode;
            this._userGroup = userGroup;
            this._userEndYmd = userEndYmd;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV2003U00CbxActorRequest();
        }
    }
}