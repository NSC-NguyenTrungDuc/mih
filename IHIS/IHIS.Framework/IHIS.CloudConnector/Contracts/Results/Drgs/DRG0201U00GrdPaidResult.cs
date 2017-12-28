using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0201U00GrdPaidResult : AbstractContractResult
	{
		private List<DRG0201U00GrdPaidInfo> _grdPaidItem = new List<DRG0201U00GrdPaidInfo>();

		public List<DRG0201U00GrdPaidInfo> GrdPaidItem
		{
			get { return this._grdPaidItem; }
			set { this._grdPaidItem = value; }
		}

		public DRG0201U00GrdPaidResult() { }

	}
}