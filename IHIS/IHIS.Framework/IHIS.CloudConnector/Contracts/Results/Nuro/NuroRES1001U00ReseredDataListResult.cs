using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable ]
	public class NuroRES1001U00ReseredDataListResult : AbstractContractResult
	{
		private List<NuroRES1001U00ReseredDataListItemInfo> _reseredDataListItem = new List<NuroRES1001U00ReseredDataListItemInfo>();

		public List<NuroRES1001U00ReseredDataListItemInfo> ReseredDataListItem
		{
			get { return this._reseredDataListItem; }
			set { this._reseredDataListItem = value; }
		}

		public NuroRES1001U00ReseredDataListResult() { }

	}
}