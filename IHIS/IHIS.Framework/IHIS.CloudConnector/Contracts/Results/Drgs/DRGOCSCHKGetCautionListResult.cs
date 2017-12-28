using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRGOCSCHKGetCautionListResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _listItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ListItem
		{
			get { return this._listItem; }
			set { this._listItem = value; }
		}

		public DRGOCSCHKGetCautionListResult() { }

	}
}