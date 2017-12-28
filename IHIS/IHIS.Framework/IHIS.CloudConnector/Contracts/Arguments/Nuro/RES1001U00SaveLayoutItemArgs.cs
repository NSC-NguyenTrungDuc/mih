using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class RES1001U00SaveLayoutItemArgs : IContractArgs
    {
        protected bool Equals(RES1001U00SaveLayoutItemArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_layoutItem, other._layoutItem) && string.Equals(_hospCodeLink, other._hospCodeLink) && _tabIsAll.Equals(other._tabIsAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RES1001U00SaveLayoutItemArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_layoutItem != null ? _layoutItem.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _tabIsAll.GetHashCode();
                return hashCode;
            }
        }

        private String _userId;
        private List<RES1001U00SaveLayoutItemInfo> _layoutItem = new List<RES1001U00SaveLayoutItemInfo>();
        private String _hospCodeLink;
        private Boolean _tabIsAll;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<RES1001U00SaveLayoutItemInfo> LayoutItem
        {
            get { return this._layoutItem; }
            set { this._layoutItem = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public Boolean TabIsAll
        {
            get { return this._tabIsAll; }
            set { this._tabIsAll = value; }
        }

        public RES1001U00SaveLayoutItemArgs() { }

        public RES1001U00SaveLayoutItemArgs(String userId, List<RES1001U00SaveLayoutItemInfo> layoutItem, String hospCodeLink, Boolean tabIsAll)
        {
            this._userId = userId;
            this._layoutItem = layoutItem;
            this._hospCodeLink = hospCodeLink;
            this._tabIsAll = tabIsAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.RES1001U00SaveLayoutItemRequest();
        }
    }
}