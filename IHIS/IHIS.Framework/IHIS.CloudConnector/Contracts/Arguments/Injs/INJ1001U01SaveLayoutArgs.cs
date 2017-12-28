using System;
using IHIS.CloudConnector.Contracts.Models.Injs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
    public class INJ1001U01SaveLayoutArgs : IContractArgs
    {
        protected bool Equals(INJ1001U01SaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_updId, other._updId) && Equals(_saveLayoutItem, other._saveLayoutItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1001U01SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_updId != null ? _updId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_saveLayoutItem != null ? _saveLayoutItem.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _updId;
        private List<INJ1001U01SaveLayoutInfo> _saveLayoutItem = new List<INJ1001U01SaveLayoutInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public List<INJ1001U01SaveLayoutInfo> SaveLayoutItem
        {
            get { return this._saveLayoutItem; }
            set { this._saveLayoutItem = value; }
        }

        public INJ1001U01SaveLayoutArgs() { }

        public INJ1001U01SaveLayoutArgs(String userId, String updId, List<INJ1001U01SaveLayoutInfo> saveLayoutItem)
        {
            this._userId = userId;
            this._updId = updId;
            this._saveLayoutItem = saveLayoutItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INJ1001U01SaveLayoutRequest();
        }
    }
}