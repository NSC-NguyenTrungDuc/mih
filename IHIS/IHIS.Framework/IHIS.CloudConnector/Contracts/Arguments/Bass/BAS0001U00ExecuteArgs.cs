using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0001U00ExecuteArgs : IContractArgs
    {
        protected bool Equals(BAS0001U00ExecuteArgs other)
        {
            return Equals(_itemInfo, other._itemInfo) && string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0001U00ExecuteArgs) obj);
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

        private List<BAS0001U00GrdBAS0001Info> _itemInfo = new List<BAS0001U00GrdBAS0001Info>();
        private String _userId;
        private String _hospCode;

        public List<BAS0001U00GrdBAS0001Info> ItemInfo
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

        public BAS0001U00ExecuteArgs() { }

        public BAS0001U00ExecuteArgs(List<BAS0001U00GrdBAS0001Info> itemInfo, String userId, String hospCode)
        {
            this._itemInfo = itemInfo;
            this._userId = userId;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0001U00ExecuteRequest();
        }
    }
}