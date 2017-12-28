using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0131U00GetFwkCodeResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _listItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ListItem
		{
			get { return this._listItem; }
			set { this._listItem = value; }
		}

		public OCS0131U00GetFwkCodeResult() { }

	}
}