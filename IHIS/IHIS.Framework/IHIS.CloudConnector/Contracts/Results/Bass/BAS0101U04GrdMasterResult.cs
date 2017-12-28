using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0101U04GrdMasterResult : AbstractContractResult
	{
		private List<BAS0101U04GrdMasterInfo> _grdMasterItem = new List<BAS0101U04GrdMasterInfo>();

		public List<BAS0101U04GrdMasterInfo> GrdMasterItem
		{
			get { return this._grdMasterItem; }
			set { this._grdMasterItem = value; }
		}

		public BAS0101U04GrdMasterResult() { }

	}
}