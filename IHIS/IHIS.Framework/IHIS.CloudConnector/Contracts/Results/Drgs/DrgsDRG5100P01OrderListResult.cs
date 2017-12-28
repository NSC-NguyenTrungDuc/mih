using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01OrderListResult : AbstractContractResult
	{
		private List<DrgsDRG5100P01OrderListItemInfo> _orderList = new List<DrgsDRG5100P01OrderListItemInfo>();

		public List<DrgsDRG5100P01OrderListItemInfo> OrderList
		{
			get { return this._orderList; }
			set { this._orderList = value; }
		}

		public DrgsDRG5100P01OrderListResult() { }

	}
}