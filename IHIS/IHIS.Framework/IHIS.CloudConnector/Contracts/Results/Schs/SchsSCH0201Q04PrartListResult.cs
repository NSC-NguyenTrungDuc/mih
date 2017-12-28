using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201Q04PrartListResult : AbstractContractResult
	{
		private List<SchsSCH0201Q04PrartListItemInfo> _prartListItem = new List<SchsSCH0201Q04PrartListItemInfo>();

		public List<SchsSCH0201Q04PrartListItemInfo> PrartListItem
		{
			get { return this._prartListItem; }
			set { this._prartListItem = value; }
		}

		public SchsSCH0201Q04PrartListResult() { }

	}
}