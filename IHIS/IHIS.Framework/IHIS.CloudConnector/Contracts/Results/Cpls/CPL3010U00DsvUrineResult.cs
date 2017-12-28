using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3010U00DsvUrineResult : AbstractContractResult
	{
		private List<CPL3010U00DsvUrineListItemInfo> _dsvUrineItem = new List<CPL3010U00DsvUrineListItemInfo>();

		public List<CPL3010U00DsvUrineListItemInfo> DsvUrineItem
		{
			get { return this._dsvUrineItem; }
			set { this._dsvUrineItem = value; }
		}

		public CPL3010U00DsvUrineResult() { }

	}
}