using System;

namespace IHIS.CloudConnector.Contracts.Results.Pfes
{
    [Serializable]
    public class PFE0101U00LayUserNameResult : AbstractContractResult
	{
		private String _userName;

		public String UserName
		{
			get { return this._userName; }
			set { this._userName = value; }
		}

		public PFE0101U00LayUserNameResult() { }

	}
}