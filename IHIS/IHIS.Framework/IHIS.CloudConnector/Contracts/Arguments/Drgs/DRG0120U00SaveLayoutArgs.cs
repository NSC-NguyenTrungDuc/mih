using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    public class DRG0120U00SaveLayoutArgs : IContractArgs
    {
        private String _userId;
        private String _hospCode;
        private List<DRG0120U00GrdDrg0120ItemInfo> _inputList = new List<DRG0120U00GrdDrg0120ItemInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public List<DRG0120U00GrdDrg0120ItemInfo> InputList
        {
            get { return this._inputList; }
            set { this._inputList = value; }
        }

        public DRG0120U00SaveLayoutArgs() { }

        public DRG0120U00SaveLayoutArgs(String userId, String hospCode, List<DRG0120U00GrdDrg0120ItemInfo> inputList)
        {
            this._userId = userId;
            this._hospCode = hospCode;
            this._inputList = inputList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DRG0120U00SaveLayoutRequest();
        }
    }
}