using System;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
	public class SCH3001U00VsvHangmogCodeResult : AbstractContractResult
	{
		private String _hangmogName;

		public String HangmogName
		{
			get { return this._hangmogName; }
			set { this._hangmogName = value; }
		}

		public SCH3001U00VsvHangmogCodeResult() { }

	}
}