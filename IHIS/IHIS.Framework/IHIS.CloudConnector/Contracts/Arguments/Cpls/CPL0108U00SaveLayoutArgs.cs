using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0108U00SaveLayoutArgs : IContractArgs
    {
        protected bool Equals(CPL0108U00SaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_inputList, other._inputList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0108U00SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_inputList != null ? _inputList.GetHashCode() : 0);
            }
        }

        private String _userId;
        private List<CPL0108U00InitGrdDetailListItemInfo> _inputList = new List<CPL0108U00InitGrdDetailListItemInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<CPL0108U00InitGrdDetailListItemInfo> InputList
        {
            get { return this._inputList; }
            set { this._inputList = value; }
        }

        public CPL0108U00SaveLayoutArgs() { }

        public CPL0108U00SaveLayoutArgs(String userId, List<CPL0108U00InitGrdDetailListItemInfo> inputList)
        {
            this._userId = userId;
            this._inputList = inputList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0108U00SaveLayoutRequest();
        }
    }
}