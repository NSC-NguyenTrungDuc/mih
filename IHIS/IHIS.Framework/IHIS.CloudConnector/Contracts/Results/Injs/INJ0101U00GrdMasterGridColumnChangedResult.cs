using System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ0101U00GrdMasterGridColumnChangedResult : AbstractContractResult
	{
		private String _yValue;

		public String YValue
		{
			get { return this._yValue; }
			set { this._yValue = value; }
		}

		public INJ0101U00GrdMasterGridColumnChangedResult() { }

	}
}