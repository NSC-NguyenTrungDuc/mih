using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
	public class CheckAdminUserInfo
	{
		private String _userScrt;
		private String _userGroup;
		private String _userYn;

		public String UserScrt
		{
			get { return this._userScrt; }
			set { this._userScrt = value; }
		}

		public String UserGroup
		{
			get { return this._userGroup; }
			set { this._userGroup = value; }
		}

		public String UserYn
		{
			get { return this._userYn; }
			set { this._userYn = value; }
		}

		public CheckAdminUserInfo() { }

		public CheckAdminUserInfo(String userScrt, String userGroup, String userYn)
		{
			this._userScrt = userScrt;
			this._userGroup = userGroup;
			this._userYn = userYn;
		}

	}
}