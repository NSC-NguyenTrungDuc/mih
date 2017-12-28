using System;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
	public class SCH3001U00VsvUserNameResult : AbstractContractResult
	{
		private String _userName;

		public String UserName
		{
			get { return this._userName; }
			set { this._userName = value; }
		}

		public SCH3001U00VsvUserNameResult() { }

	}
}