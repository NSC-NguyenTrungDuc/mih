using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201Q04GetFormLoadResult : AbstractContractResult
	{
		private List<SchsSCH0201Q04GetMonthReserListInfo> _monthReserItem = new List<SchsSCH0201Q04GetMonthReserListInfo>();
		private List<SchsSCH0201Q04PrartListItemInfo> _prartItem = new List<SchsSCH0201Q04PrartListItemInfo>();

		public List<SchsSCH0201Q04GetMonthReserListInfo> MonthReserItem
		{
			get { return this._monthReserItem; }
			set { this._monthReserItem = value; }
		}

		public List<SchsSCH0201Q04PrartListItemInfo> PrartItem
		{
			get { return this._prartItem; }
			set { this._prartItem = value; }
		}

		public SchsSCH0201Q04GetFormLoadResult() { }

	}
}