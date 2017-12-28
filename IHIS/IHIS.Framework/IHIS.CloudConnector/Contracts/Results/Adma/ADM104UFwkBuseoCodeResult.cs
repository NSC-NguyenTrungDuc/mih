using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM104UFwkBuseoCodeResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _itemInfo = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public ADM104UFwkBuseoCodeResult() { }

	}
}