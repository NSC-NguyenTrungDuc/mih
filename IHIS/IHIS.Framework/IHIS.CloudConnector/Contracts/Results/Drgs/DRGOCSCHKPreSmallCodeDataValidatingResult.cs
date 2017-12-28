using System;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRGOCSCHKPreSmallCodeDataValidatingResult : AbstractContractResult
	{
		private String _cautionName;

		public String CautionName
		{
			get { return this._cautionName; }
			set { this._cautionName = value; }
		}

		public DRGOCSCHKPreSmallCodeDataValidatingResult() { }

	}
}