using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH0201Q05LayReserListResult : AbstractContractResult
	{
		private List<SCH0201Q05LayReserListInfo> _reserListItem = new List<SCH0201Q05LayReserListInfo>();

		public List<SCH0201Q05LayReserListInfo> ReserListItem
		{
			get { return this._reserListItem; }
			set { this._reserListItem = value; }
		}

		public SCH0201Q05LayReserListResult() { }

	}
}