using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
    public class OCS2015U31EmrTemplateSaveLayoutArgs : IContractArgs
    {
    protected bool Equals(OCS2015U31EmrTemplateSaveLayoutArgs other)
    {
        return string.Equals(_userId, other._userId) && string.Equals(_userGroup, other._userGroup) && Equals(_saveLayoutTemplateItem, other._saveLayoutTemplateItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U31EmrTemplateSaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userGroup != null ? _userGroup.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_saveLayoutTemplateItem != null ? _saveLayoutTemplateItem.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _userId;
        private String _userGroup;
        private List<OCS2015U31EmrTemplateSaveLayoutInfo> _saveLayoutTemplateItem = new List<OCS2015U31EmrTemplateSaveLayoutInfo>();

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

        public List<OCS2015U31EmrTemplateSaveLayoutInfo> SaveLayoutTemplateItem
        {
            get { return this._saveLayoutTemplateItem; }
            set { this._saveLayoutTemplateItem = value; }
        }

        public OCS2015U31EmrTemplateSaveLayoutArgs() { }

        public OCS2015U31EmrTemplateSaveLayoutArgs(String userId, String userGroup, List<OCS2015U31EmrTemplateSaveLayoutInfo> saveLayoutTemplateItem)
        {
            this._userId = userId;
            this._userGroup = userGroup;
            this._saveLayoutTemplateItem = saveLayoutTemplateItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U31EmrTemplateSaveLayoutRequest();
        }
    }
}