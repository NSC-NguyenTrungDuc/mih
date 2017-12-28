using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
    public class OCS2015U30EmrTagSaveLayoutArgs : IContractArgs
    {
    protected bool Equals(OCS2015U30EmrTagSaveLayoutArgs other)
    {
        return string.Equals(_userId, other._userId) && string.Equals(_userGroup, other._userGroup) && Equals(_saveLayoutRootItem, other._saveLayoutRootItem) && Equals(_saveLayoutNodeItem, other._saveLayoutNodeItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U30EmrTagSaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userGroup != null ? _userGroup.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_saveLayoutRootItem != null ? _saveLayoutRootItem.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_saveLayoutNodeItem != null ? _saveLayoutNodeItem.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _userId;
        private String _userGroup;
        private List<OCS2015U30EmrTagSaveLayoutInfo> _saveLayoutRootItem = new List<OCS2015U30EmrTagSaveLayoutInfo>();
        private List<OCS2015U30EmrTagSaveLayoutInfo> _saveLayoutNodeItem = new List<OCS2015U30EmrTagSaveLayoutInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String UserGroup
        {
            get { return this._userGroup; }
            set { this._userGroup = value; }
        }

        public List<OCS2015U30EmrTagSaveLayoutInfo> SaveLayoutRootItem
        {
            get { return this._saveLayoutRootItem; }
            set { this._saveLayoutRootItem = value; }
        }

        public List<OCS2015U30EmrTagSaveLayoutInfo> SaveLayoutNodeItem
        {
            get { return this._saveLayoutNodeItem; }
            set { this._saveLayoutNodeItem = value; }
        }

        public OCS2015U30EmrTagSaveLayoutArgs() { }

        public OCS2015U30EmrTagSaveLayoutArgs(String userId, String userGroup, List<OCS2015U30EmrTagSaveLayoutInfo> saveLayoutRootItem, List<OCS2015U30EmrTagSaveLayoutInfo> saveLayoutNodeItem)
        {
            this._userId = userId;
            this._userGroup = userGroup;
            this._saveLayoutRootItem = saveLayoutRootItem;
            this._saveLayoutNodeItem = saveLayoutNodeItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U30EmrTagSaveLayoutRequest();
        }
    }
}