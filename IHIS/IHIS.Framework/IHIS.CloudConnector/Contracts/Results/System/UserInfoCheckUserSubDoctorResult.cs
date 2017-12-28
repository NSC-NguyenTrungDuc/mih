using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class UserInfoCheckUserSubDoctorResult : AbstractContractResult
	{
		private UserItemInfo _userItemInfo;
		private String _errorMessage;
		private List<ComboListItemInfo> _cboList = new List<ComboListItemInfo>();

		public UserItemInfo UserItemInfo
		{
			get { return this._userItemInfo; }
			set { this._userItemInfo = value; }
		}

		public String ErrorMessage
		{
			get { return this._errorMessage; }
			set { this._errorMessage = value; }
		}

		public List<ComboListItemInfo> CboList
		{
			get { return this._cboList; }
			set { this._cboList = value; }
		}

		public UserInfoCheckUserSubDoctorResult() { }

	}
}