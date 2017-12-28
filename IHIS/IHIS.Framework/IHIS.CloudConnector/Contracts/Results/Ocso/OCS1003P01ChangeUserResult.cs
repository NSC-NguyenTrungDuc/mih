using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OCS1003P01ChangeUserResult : AbstractContractResult
	{
		private String _gwaName;

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public OCS1003P01ChangeUserResult() { }

	}
}