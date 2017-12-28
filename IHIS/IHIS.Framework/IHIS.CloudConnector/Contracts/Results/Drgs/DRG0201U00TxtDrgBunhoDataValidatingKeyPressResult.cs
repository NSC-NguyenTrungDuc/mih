using System;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0201U00TxtDrgBunhoDataValidatingKeyPressResult : AbstractContractResult
	{
		private String _result;

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public DRG0201U00TxtDrgBunhoDataValidatingKeyPressResult() { }

	}
}