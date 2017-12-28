using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
    public class OCS2015U31GetADM3200UserArgs : IContractArgs
    {
    protected bool Equals(OCS2015U31GetADM3200UserArgs other)
    {
        return string.Equals(_userId, other._userId) && string.Equals(_userGroup, other._userGroup);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U31GetADM3200UserArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_userGroup != null ? _userGroup.GetHashCode() : 0);
        }
    }

    private String _userId;
        private String _userGroup;

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

        public OCS2015U31GetADM3200UserArgs() { }

        public OCS2015U31GetADM3200UserArgs(String userId, String userGroup)
        {
            this._userId = userId;
            this._userGroup = userGroup;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U31GetADM3200UserRequest();
        }
    }
}