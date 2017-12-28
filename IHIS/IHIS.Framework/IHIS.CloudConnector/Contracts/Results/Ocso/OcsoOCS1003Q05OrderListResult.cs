using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003Q05OrderListResult : AbstractContractResult
	{
		private List<OcsoOCS1003Q05OrderListItemInfo> _orderListItem = new List<OcsoOCS1003Q05OrderListItemInfo>();

		public List<OcsoOCS1003Q05OrderListItemInfo> OrderListItem
		{
			get { return this._orderListItem; }
			set { this._orderListItem = value; }
		}

		public OcsoOCS1003Q05OrderListResult() { }

	}
}