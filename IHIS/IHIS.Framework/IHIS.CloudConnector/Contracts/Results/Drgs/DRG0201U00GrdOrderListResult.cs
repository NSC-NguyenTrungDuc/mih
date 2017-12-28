using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0201U00GrdOrderListResult : AbstractContractResult
	{
		private List<DRG0201U00GrdOrderListInfo> _grdOrderListItem = new List<DRG0201U00GrdOrderListInfo>();

		public List<DRG0201U00GrdOrderListInfo> GrdOrderListItem
		{
			get { return this._grdOrderListItem; }
			set { this._grdOrderListItem = value; }
		}

		public DRG0201U00GrdOrderListResult() { }

	}
}