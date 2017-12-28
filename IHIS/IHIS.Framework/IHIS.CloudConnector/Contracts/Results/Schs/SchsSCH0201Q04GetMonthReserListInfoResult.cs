using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201Q04GetMonthReserListInfoResult : AbstractContractResult
	{
		private List<SchsSCH0201Q04GetMonthReserListInfo> _monthReserListItem = new List<SchsSCH0201Q04GetMonthReserListInfo>();

		public List<SchsSCH0201Q04GetMonthReserListInfo> MonthReserListItem
		{
			get { return this._monthReserListItem; }
			set { this._monthReserListItem = value; }
		}

		public SchsSCH0201Q04GetMonthReserListInfoResult() { }

	}
}