using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class HOTCODEMASTERSaveLayoutArgs : IContractArgs
    {
        protected bool Equals(HOTCODEMASTERSaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode) && string.Equals(_truncateYn, other._truncateYn) && Equals(_layoutItem, other._layoutItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HOTCODEMASTERSaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_truncateYn != null ? _truncateYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_layoutItem != null ? _layoutItem.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _hospCode;
        private String _truncateYn;
        private List<HOTCODEMASTERGetGrdListInfo> _layoutItem = new List<HOTCODEMASTERGetGrdListInfo>();

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

        public String TruncateYn
        {
            get { return this._truncateYn; }
            set { this._truncateYn = value; }
        }

        public List<HOTCODEMASTERGetGrdListInfo> LayoutItem
        {
            get { return this._layoutItem; }
            set { this._layoutItem = value; }
        }

        public HOTCODEMASTERSaveLayoutArgs() { }

        public HOTCODEMASTERSaveLayoutArgs(String userId, String hospCode, String truncateYn, List<HOTCODEMASTERGetGrdListInfo> layoutItem)
        {
            this._userId = userId;
            this._hospCode = hospCode;
            this._truncateYn = truncateYn;
            this._layoutItem = layoutItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.HOTCODEMASTERSaveLayoutRequest();
        }
    }
}