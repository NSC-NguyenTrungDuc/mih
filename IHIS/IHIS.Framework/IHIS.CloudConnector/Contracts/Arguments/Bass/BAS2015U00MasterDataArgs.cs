using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Messaging;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS2015U00MasterDataArgs : IContractArgs
    {
        protected bool Equals(BAS2015U00MasterDataArgs other)
        {
            return _kinkiType == other._kinkiType && Equals(_data, other._data) && _actionType == other._actionType && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS2015U00MasterDataArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (int) _kinkiType;
                hashCode = (hashCode*397) ^ (_data != null ? _data.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) _actionType;
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private KinkiType _kinkiType;
        private byte[] _data = null;
        private ActionType _actionType;
        private String _userId;

        public KinkiType KinkiType
        {
            get { return this._kinkiType; }
            set { this._kinkiType = value; }
        }

        public byte[] Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        public ActionType ActionType
        {
            get { return this._actionType; }
            set { this._actionType = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public BAS2015U00MasterDataArgs() { }

        public BAS2015U00MasterDataArgs(KinkiType kinkiType, byte[] data, ActionType actionType, String userId)
        {
            this._kinkiType = kinkiType;
            this._data = data;
            this._actionType = actionType;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS2015U00MasterDataRequest();
        }
    }
}