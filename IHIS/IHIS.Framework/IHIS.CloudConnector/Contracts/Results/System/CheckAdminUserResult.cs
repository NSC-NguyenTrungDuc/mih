using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class CheckAdminUserResult : AbstractContractResult
	{
		private List<CheckAdminUserInfo> _userInfo = new List<CheckAdminUserInfo>();

		public List<CheckAdminUserInfo> UserInfo
		{
			get { return this._userInfo; }
			set { this._userInfo = value; }
		}

		public CheckAdminUserResult() { }

	}
}