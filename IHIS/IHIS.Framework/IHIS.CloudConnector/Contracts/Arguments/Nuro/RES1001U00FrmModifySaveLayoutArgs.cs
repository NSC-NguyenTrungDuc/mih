using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class RES1001U00FrmModifySaveLayoutArgs : IContractArgs
    {
        protected bool Equals(RES1001U00FrmModifySaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_saveLayoutItem, other._saveLayoutItem) && string.Equals(_hospCodeLink, other._hospCodeLink);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RES1001U00FrmModifySaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_saveLayoutItem != null ? _saveLayoutItem.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private List<RES1001U00FrmModifySaveLayoutInfo> _saveLayoutItem = new List<RES1001U00FrmModifySaveLayoutInfo>();
        private String _hospCodeLink;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<RES1001U00FrmModifySaveLayoutInfo> SaveLayoutItem
        {
            get { return this._saveLayoutItem; }
            set { this._saveLayoutItem = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public RES1001U00FrmModifySaveLayoutArgs() { }

        public RES1001U00FrmModifySaveLayoutArgs(String userId, List<RES1001U00FrmModifySaveLayoutInfo> saveLayoutItem, String hospCodeLink)
        {
            this._userId = userId;
            this._saveLayoutItem = saveLayoutItem;
            this._hospCodeLink = hospCodeLink;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.RES1001U00FrmModifySaveLayoutRequest();
        }
    }
}