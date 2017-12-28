using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3020U00GrdPaResult : AbstractContractResult
	{
		private List<CPL3020U00GrdPaListItemInfo> _grdPaItem = new List<CPL3020U00GrdPaListItemInfo>();

		public List<CPL3020U00GrdPaListItemInfo> GrdPaItem
		{
			get { return this._grdPaItem; }
			set { this._grdPaItem = value; }
		}

		public CPL3020U00GrdPaResult() { }

	}
}