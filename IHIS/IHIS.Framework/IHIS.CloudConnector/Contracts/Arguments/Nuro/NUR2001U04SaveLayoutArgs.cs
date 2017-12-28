using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NUR2001U04SaveLayoutArgs : IContractArgs
    {
        protected bool Equals(NUR2001U04SaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode) && Equals(_saveLayoutItem, other._saveLayoutItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR2001U04SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_saveLayoutItem != null ? _saveLayoutItem.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _hospCode;
        private List<NUR2001U04SaveLayoutInfo> _saveLayoutItem = new List<NUR2001U04SaveLayoutInfo>();

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

        public List<NUR2001U04SaveLayoutInfo> SaveLayoutItem
        {
            get { return this._saveLayoutItem; }
            set { this._saveLayoutItem = value; }
        }

        public NUR2001U04SaveLayoutArgs() { }

        public NUR2001U04SaveLayoutArgs(String userId, String hospCode, List<NUR2001U04SaveLayoutInfo> saveLayoutItem)
        {
            this._userId = userId;
            this._hospCode = hospCode;
            this._saveLayoutItem = saveLayoutItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2001U04SaveLayoutRequest();
        }
    }
}