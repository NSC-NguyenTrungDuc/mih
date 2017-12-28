using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM101UGrdSystemResult : AbstractContractResult
	{
		private List<ADM101UgrdSystemItemInfo> _itemInfo = new List<ADM101UgrdSystemItemInfo>();

		public List<ADM101UgrdSystemItemInfo> ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public ADM101UGrdSystemResult() { }

	}
}