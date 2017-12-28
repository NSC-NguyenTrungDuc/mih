using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Chts;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
	public class CHT0117GrdCHT0118InitResult : AbstractContractResult
	{
		private List<CHT0117GrdCHT0118InitListItemInfo> _listItemInfo = new List<CHT0117GrdCHT0118InitListItemInfo>();

		public List<CHT0117GrdCHT0118InitListItemInfo> ListItemInfo
		{
			get { return this._listItemInfo; }
			set { this._listItemInfo = value; }
		}

		public CHT0117GrdCHT0118InitResult() { }

	}
}