using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class MainFormGetMsgSystemArgs : IContractArgs
    {
    protected bool Equals(MainFormGetMsgSystemArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_userId, other._userId) && string.Equals(_groupId, other._groupId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MainFormGetMsgSystemArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_groupId != null ? _groupId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _hospCode;
        private String _userId;
        private String _groupId;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String GroupId
        {
            get { return this._groupId; }
            set { this._groupId = value; }
        }

        public MainFormGetMsgSystemArgs() { }

        public MainFormGetMsgSystemArgs(String hospCode, String userId, String groupId)
        {
            this._hospCode = hospCode;
            this._userId = userId;
            this._groupId = groupId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.MainFormGetMsgSystemRequest();
        }
    }
}