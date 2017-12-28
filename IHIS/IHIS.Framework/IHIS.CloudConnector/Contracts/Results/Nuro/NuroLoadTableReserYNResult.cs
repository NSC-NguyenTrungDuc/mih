using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroLoadTableReserYNResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _jubsuTime = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> JubsuTime
		{
			get { return this._jubsuTime; }
			set { this._jubsuTime = value; }
		}

		public NuroLoadTableReserYNResult() { }

	}
}