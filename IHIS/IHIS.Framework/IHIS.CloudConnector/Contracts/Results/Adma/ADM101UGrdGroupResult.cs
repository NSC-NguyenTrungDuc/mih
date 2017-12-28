using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM101UGrdGroupResult : AbstractContractResult
	{
		private List<ADM101UGrdGroupItemInfo> _itemInfo = new List<ADM101UGrdGroupItemInfo>();

		public List<ADM101UGrdGroupItemInfo> ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public ADM101UGrdGroupResult() { }

	}
}