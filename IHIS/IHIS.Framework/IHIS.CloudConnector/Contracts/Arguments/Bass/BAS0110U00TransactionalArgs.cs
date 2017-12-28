using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0110U00TransactionalArgs : IContractArgs
    {
        protected bool Equals(BAS0110U00TransactionalArgs other)
        {
            return Equals(_listInfo, other._listInfo) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0110U00TransactionalArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_listInfo != null ? _listInfo.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private List<BAS0110U00GrdJohapListItemInfo> _listInfo = new List<BAS0110U00GrdJohapListItemInfo>();
        private String _userId;

        public List<BAS0110U00GrdJohapListItemInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public BAS0110U00TransactionalArgs() { }

        public BAS0110U00TransactionalArgs(List<BAS0110U00GrdJohapListItemInfo> listInfo, String userId)
        {
            this._listInfo = listInfo;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0110U00TransactionalRequest();
        }
    }
}