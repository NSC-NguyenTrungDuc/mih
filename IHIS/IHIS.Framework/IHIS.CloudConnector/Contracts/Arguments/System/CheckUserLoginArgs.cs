using System;
using IHIS.CloudConnector.Contracts.Models.System;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
	public class CheckUserLoginArgs : IContractArgs
	{
    protected bool Equals(CheckUserLoginArgs other)
    {
        return string.Equals(_userId, other._userId) && string.Equals(_systemId, other._systemId) && Equals(_userInfo, other._userInfo);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((CheckUserLoginArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_systemId != null ? _systemId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userInfo != null ? _userInfo.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _userId;
		private String _systemId;
		private UserRequestInfo _userInfo;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String SystemId
		{
			get { return this._systemId; }
			set { this._systemId = value; }
		}

		public UserRequestInfo UserInfo
		{
			get { return this._userInfo; }
			set { this._userInfo = value; }
		}

		public CheckUserLoginArgs() { }

		public CheckUserLoginArgs(String userId, String systemId, UserRequestInfo userInfo)
		{
			this._userId = userId;
			this._systemId = systemId;
			this._userInfo = userInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new IHIS.CloudConnector.Messaging.CheckUserLoginRequest();
		}
	}
}