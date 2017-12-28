using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0102U00GrdMasterResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _listInfo = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ListInfo
		{
			get { return this._listInfo; }
			set { this._listInfo = value; }
		}

		public DRG0102U00GrdMasterResult() { }

	}
}