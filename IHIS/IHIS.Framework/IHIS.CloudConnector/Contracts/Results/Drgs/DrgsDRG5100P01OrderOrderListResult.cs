using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01OrderOrderListResult : AbstractContractResult
	{
		private List<DrgsDRG5100P01OrderOrderListItemInfo> _orderOrderList = new List<DrgsDRG5100P01OrderOrderListItemInfo>();

		public List<DrgsDRG5100P01OrderOrderListItemInfo> OrderOrderList
		{
			get { return this._orderOrderList; }
			set { this._orderOrderList = value; }
		}

		public DrgsDRG5100P01OrderOrderListResult() { }

	}
}