using System;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0102U00GrdMasterGridColumnChangedResult : AbstractContractResult
	{
		private String _x;

		public String X
		{
			get { return this._x; }
			set { this._x = value; }
		}

		public DRG0102U00GrdMasterGridColumnChangedResult() { }

	}
}