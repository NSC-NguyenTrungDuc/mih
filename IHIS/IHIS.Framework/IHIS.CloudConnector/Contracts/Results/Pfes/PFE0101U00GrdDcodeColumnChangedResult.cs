using System;

namespace IHIS.CloudConnector.Contracts.Results.Pfes
{
    [Serializable]
    public class PFE0101U00GrdDcodeColumnChangedResult : AbstractContractResult
	{
		private String _dupYn;
		private String _userName;

		public String DupYn
		{
			get { return this._dupYn; }
			set { this._dupYn = value; }
		}

		public String UserName
		{
			get { return this._userName; }
			set { this._userName = value; }
		}

		public PFE0101U00GrdDcodeColumnChangedResult() { }

	}
}