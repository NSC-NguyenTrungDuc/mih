using System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0210U00layDupCheckResult : AbstractContractResult
	{
		private String _layDupCheck;

		public String LayDupCheck
		{
			get { return this._layDupCheck; }
			set { this._layDupCheck = value; }
		}

		public BAS0210U00layDupCheckResult() { }

	}
}