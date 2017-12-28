using System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3020U00LayCommonResult : AbstractContractResult
	{
		private String _userName;

		public String UserName
		{
			get { return this._userName; }
			set { this._userName = value; }
		}

		public CPL3020U00LayCommonResult() { }

	}
}