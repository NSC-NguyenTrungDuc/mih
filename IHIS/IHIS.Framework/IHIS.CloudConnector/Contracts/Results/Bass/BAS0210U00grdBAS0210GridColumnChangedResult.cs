using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0210U00grdBAS0210GridColumnChangedResult : AbstractContractResult
	{
		private List<BAS0210U00grdBAS0210GridColumnChangedItemInfo> _gridColumnChanged = new List<BAS0210U00grdBAS0210GridColumnChangedItemInfo>();

		public List<BAS0210U00grdBAS0210GridColumnChangedItemInfo> GridColumnChanged
		{
			get { return this._gridColumnChanged; }
			set { this._gridColumnChanged = value; }
		}

		public BAS0210U00grdBAS0210GridColumnChangedResult() { }

	}
}