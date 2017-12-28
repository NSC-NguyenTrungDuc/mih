using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class BIL2016U00SaveGrdMasterArgs : IContractArgs
    {
        private List<BIL2016U00DetailServiceInfo> _info = new List<BIL2016U00DetailServiceInfo>();

        public List<BIL2016U00DetailServiceInfo> Info
        {
            get { return this._info; }
            set { this._info = value; }
        }

        public BIL2016U00SaveGrdMasterArgs() { }

        public BIL2016U00SaveGrdMasterArgs(List<BIL2016U00DetailServiceInfo> info)
        {
            this._info = info;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL2016U00SaveGrdMasterRequest();
        }
    }
}