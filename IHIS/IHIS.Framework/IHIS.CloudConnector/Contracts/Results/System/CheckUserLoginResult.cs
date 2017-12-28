using System;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class CheckUserLoginResult : AbstractContractResult
	{
		private String _subPartDoctor;
		private UserItemInfo _userItemInfo;
		private String _errorMessage;

		public String SubPartDoctor
		{
			get { return this._subPartDoctor; }
			set { this._subPartDoctor = value; }
		}

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

		public CheckUserLoginResult() { }

	}
}