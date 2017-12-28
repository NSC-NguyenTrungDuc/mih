using System;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
	public class UserInfoCheckUserSubDoctorArgs : IContractArgs
	{
    protected bool Equals(UserInfoCheckUserSubDoctorArgs other)
    {
        return string.Equals(_gwa, other._gwa) && Equals(_userInfo, other._userInfo);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((UserInfoCheckUserSubDoctorArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_gwa != null ? _gwa.GetHashCode() : 0)*397) ^ (_userInfo != null ? _userInfo.GetHashCode() : 0);
        }
    }

    private String _gwa;
		private UserRequestInfo _userInfo;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public UserRequestInfo UserInfo
		{
			get { return this._userInfo; }
			set { this._userInfo = value; }
		}

		public UserInfoCheckUserSubDoctorArgs() { }

		public UserInfoCheckUserSubDoctorArgs(String gwa, UserRequestInfo userInfo)
		{
			this._gwa = gwa;
			this._userInfo = userInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new IHIS.CloudConnector.Messaging.UserInfoCheckUserSubDoctorRequest();
		}
	}
}