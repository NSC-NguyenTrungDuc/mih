using System;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
	public class CHT0117grdCHT0117CheckResult : AbstractContractResult
	{
		private String _chkResult;

		public String ChkResult
		{
			get { return this._chkResult; }
			set { this._chkResult = value; }
		}

		public CHT0117grdCHT0117CheckResult() { }

	}
}