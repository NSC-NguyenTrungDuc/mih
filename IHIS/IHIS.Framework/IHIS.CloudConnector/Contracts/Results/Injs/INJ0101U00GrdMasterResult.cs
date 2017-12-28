using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ0101U00GrdMasterResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _listItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ListItem
		{
			get { return this._listItem; }
			set { this._listItem = value; }
		}

		public INJ0101U00GrdMasterResult() { }

	}
}