using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES1001U00ReserListResult : AbstractContractResult
	{
		private List<NuroRES1001U00ReserListItemInfo> _reserListItem = new List<NuroRES1001U00ReserListItemInfo>();

		public List<NuroRES1001U00ReserListItemInfo> ReserListItem
		{
			get { return this._reserListItem; }
			set { this._reserListItem = value; }
		}

		public NuroRES1001U00ReserListResult() { }

	}
}