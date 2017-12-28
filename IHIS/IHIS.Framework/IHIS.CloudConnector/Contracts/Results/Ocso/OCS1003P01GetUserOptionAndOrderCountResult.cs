using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OCS1003P01GetUserOptionAndOrderCountResult : AbstractContractResult
	{
		private String _userOptionValue;
		private String _orderCountValue;

		public String UserOptionValue
		{
			get { return this._userOptionValue; }
			set { this._userOptionValue = value; }
		}

		public String OrderCountValue
		{
			get { return this._orderCountValue; }
			set { this._orderCountValue = value; }
		}

		public OCS1003P01GetUserOptionAndOrderCountResult() { }

	}
}