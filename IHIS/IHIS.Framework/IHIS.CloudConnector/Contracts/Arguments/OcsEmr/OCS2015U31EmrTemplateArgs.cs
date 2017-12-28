using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
    public class OCS2015U31EmrTemplateArgs : IContractArgs
    {
    protected bool Equals(OCS2015U31EmrTemplateArgs other)
    {
        return string.Equals(_sysId, other._sysId) && string.Equals(_userGroup, other._userGroup);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U31EmrTemplateArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_sysId != null ? _sysId.GetHashCode() : 0)*397) ^ (_userGroup != null ? _userGroup.GetHashCode() : 0);
        }
    }

    private String _sysId;
        private String _userGroup;

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String UserGroup
        {
            get { return this._userGroup; }
            set { this._userGroup = value; }
        }

        public OCS2015U31EmrTemplateArgs() { }

        public OCS2015U31EmrTemplateArgs(String sysId, String userGroup)
        {
            this._sysId = sysId;
            this._userGroup = userGroup;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U31EmrTemplateRequest();
        }
    }
}