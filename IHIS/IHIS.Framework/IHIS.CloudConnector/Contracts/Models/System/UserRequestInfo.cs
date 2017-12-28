using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
	public class UserRequestInfo
	{
		private String _sysId;
		private String _userId;
		private String _userScrt;
		private String _scrtCheckYn;
		private String _ipAddr;

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String UserScrt
		{
			get { return this._userScrt; }
			set { this._userScrt = value; }
		}

		public String ScrtCheckYn
		{
			get { return this._scrtCheckYn; }
			set { this._scrtCheckYn = value; }
		}

		public String IpAddr
		{
			get { return this._ipAddr; }
			set { this._ipAddr = value; }
		}

		public UserRequestInfo() { }

		public UserRequestInfo(String sysId, String userId, String userScrt, String scrtCheckYn, String ipAddr)
		{
			this._sysId = sysId;
			this._userId = userId;
			this._userScrt = userScrt;
			this._scrtCheckYn = scrtCheckYn;
			this._ipAddr = ipAddr;
		}

	}
}