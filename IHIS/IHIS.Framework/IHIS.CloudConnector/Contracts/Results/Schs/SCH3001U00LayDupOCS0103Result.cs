using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH3001U00LayDupOCS0103Result : AbstractContractResult
	{
		private List<DataStringListItemInfo> _itemInfo = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public SCH3001U00LayDupOCS0103Result() { }

	}
}