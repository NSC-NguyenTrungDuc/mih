using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM101UGrdSystemGridColumnChangedResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _itemInfo = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public ADM101UGrdSystemGridColumnChangedResult() { }

	}
}