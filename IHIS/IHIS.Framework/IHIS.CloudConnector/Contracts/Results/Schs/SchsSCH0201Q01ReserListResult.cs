using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201Q01ReserListResult : AbstractContractResult
	{
		private List<SchsSCH0201Q01ReserListItemInfo> _reserListItem = new List<SchsSCH0201Q01ReserListItemInfo>();

		public List<SchsSCH0201Q01ReserListItemInfo> ReserListItem
		{
			get { return this._reserListItem; }
			set { this._reserListItem = value; }
		}

		public SchsSCH0201Q01ReserListResult() { }

	}
}