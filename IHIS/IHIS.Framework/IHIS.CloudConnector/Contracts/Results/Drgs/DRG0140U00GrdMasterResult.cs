using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0140U00GrdMasterResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _grdMasterItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> GrdMasterItem
		{
			get { return this._grdMasterItem; }
			set { this._grdMasterItem = value; }
		}

		public DRG0140U00GrdMasterResult() { }

	}
}