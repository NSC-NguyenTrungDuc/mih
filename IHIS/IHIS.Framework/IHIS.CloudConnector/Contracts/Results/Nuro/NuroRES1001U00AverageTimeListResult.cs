using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES1001U00AverageTimeListResult : AbstractContractResult
	{
		private List<NuroRES1001U00AverageTimeListItemInfo> _avgTimeListItem = new List<NuroRES1001U00AverageTimeListItemInfo>();

		public List<NuroRES1001U00AverageTimeListItemInfo> AvgTimeListItem
		{
			get { return this._avgTimeListItem; }
			set { this._avgTimeListItem = value; }
		}

		public NuroRES1001U00AverageTimeListResult() { }

	}
}