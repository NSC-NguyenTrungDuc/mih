using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0201U00GrdOrderDetailServerCallResult : AbstractContractResult
	{
		private List<DRG0201U00GrdOrderInfo> _grdOrderItem = new List<DRG0201U00GrdOrderInfo>();

		public List<DRG0201U00GrdOrderInfo> GrdOrderItem
		{
			get { return this._grdOrderItem; }
			set { this._grdOrderItem = value; }
		}

		public DRG0201U00GrdOrderDetailServerCallResult() { }

	}
}