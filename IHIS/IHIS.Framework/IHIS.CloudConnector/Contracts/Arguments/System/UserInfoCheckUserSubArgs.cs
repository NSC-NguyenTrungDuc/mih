using System;
using IHIS.CloudConnector.Contracts.Models.System;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
	public class UserInfoCheckUserSubArgs : IContractArgs
	{
    protected bool Equals(UserInfoCheckUserSubArgs other)
    {
        return Equals(_userInfo, other._userInfo);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((UserInfoCheckUserSubArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_userInfo != null ? _userInfo.GetHashCode() : 0);
    }

    private UserRequestInfo _userInfo;

		public UserRequestInfo UserInfo
		{
			get { return this._userInfo; }
			set { this._userInfo = value; }
		}

		public UserInfoCheckUserSubArgs() { }

		public UserInfoCheckUserSubArgs(UserRequestInfo userInfo)
		{
			this._userInfo = userInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new IHIS.CloudConnector.Messaging.UserInfoCheckUserSubRequest();
		}
	}
}