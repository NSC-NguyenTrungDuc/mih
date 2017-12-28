using System;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
    public class DrgsDRG0130U00CautionCodeResult : AbstractContractResult
	{
		private String _cautionCode;

		public String CautionCode
		{
			get { return this._cautionCode; }
			set { this._cautionCode = value; }
		}

		public DrgsDRG0130U00CautionCodeResult() { }

	}
}