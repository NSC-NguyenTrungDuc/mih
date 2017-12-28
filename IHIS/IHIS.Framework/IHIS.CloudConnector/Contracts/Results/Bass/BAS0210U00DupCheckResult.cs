using System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0210U00DupCheckResult : AbstractContractResult
	{
		private String _dupCheck;

		public String DupCheck
		{
			get { return this._dupCheck; }
			set { this._dupCheck = value; }
		}

		public BAS0210U00DupCheckResult() { }

	}
}