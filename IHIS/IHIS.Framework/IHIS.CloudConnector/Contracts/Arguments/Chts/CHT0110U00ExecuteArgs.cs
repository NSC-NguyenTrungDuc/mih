using System;
using IHIS.CloudConnector.Contracts.Models.Chts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
    public class CHT0110U00ExecuteArgs : IContractArgs
    {
        protected bool Equals(CHT0110U00ExecuteArgs other)
        {
            return Equals(_itemInfo, other._itemInfo) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0110U00ExecuteArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_itemInfo != null ? _itemInfo.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private List<CHT0110U00grdCHT0110ItemInfo> _itemInfo = new List<CHT0110U00grdCHT0110ItemInfo>();
        private String _userId;

        public List<CHT0110U00grdCHT0110ItemInfo> ItemInfo
        {
            get { return this._itemInfo; }
            set { this._itemInfo = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public CHT0110U00ExecuteArgs() { }

        public CHT0110U00ExecuteArgs(List<CHT0110U00grdCHT0110ItemInfo> itemInfo, String userId)
        {
            this._itemInfo = itemInfo;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CHT0110U00ExecuteRequest();
        }
    }
}