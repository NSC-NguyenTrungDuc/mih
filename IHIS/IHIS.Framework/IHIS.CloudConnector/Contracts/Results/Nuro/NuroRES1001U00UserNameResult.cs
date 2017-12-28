using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES1001U00UserNameResult : AbstractContractResult
	{
		private String _userName;

		public String UserName
		{
			get { return this._userName; }
			set { this._userName = value; }
		}

		public NuroRES1001U00UserNameResult() { }

	}
}