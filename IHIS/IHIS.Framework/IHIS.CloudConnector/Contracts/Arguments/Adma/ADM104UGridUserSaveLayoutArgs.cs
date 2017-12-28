using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM104UGridUserSaveLayoutArgs : IContractArgs
    {
        protected bool Equals(ADM104UGridUserSaveLayoutArgs other)
        {
            return Equals(_itemInfo, other._itemInfo) && string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM104UGridUserSaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_itemInfo != null ? _itemInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private List<ADM104UGridUserInfo> _itemInfo = new List<ADM104UGridUserInfo>();
        private String _userId;
        private String _hospCode;

        public List<ADM104UGridUserInfo> ItemInfo
        {
            get { return this._itemInfo; }
            set { this._itemInfo = value; }
        }

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

        public ADM104UGridUserSaveLayoutArgs() { }

        public ADM104UGridUserSaveLayoutArgs(List<ADM104UGridUserInfo> itemInfo, String userId, String hospCode)
        {
            this._itemInfo = itemInfo;
            this._userId = userId;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM104UGridUserSaveLayoutRequest();
        }
    }
}