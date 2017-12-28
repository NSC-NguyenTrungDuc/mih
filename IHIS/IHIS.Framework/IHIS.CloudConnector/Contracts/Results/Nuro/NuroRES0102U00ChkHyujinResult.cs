using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES0102U00ChkHyujinResult : AbstractContractResult
	{
		private String _check;

		public String Check
		{
			get { return this._check; }
			set { this._check = value; }
		}

		public NuroRES0102U00ChkHyujinResult() { }

	}
}