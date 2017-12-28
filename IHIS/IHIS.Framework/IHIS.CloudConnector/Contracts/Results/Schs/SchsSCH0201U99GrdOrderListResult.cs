using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201U99GrdOrderListResult : AbstractContractResult
	{
		private List<SchsSCH0201U99GrdOrderListInfo> _orderList = new List<SchsSCH0201U99GrdOrderListInfo>();

		public List<SchsSCH0201U99GrdOrderListInfo> OrderList
		{
			get { return this._orderList; }
			set { this._orderList = value; }
		}

		public SchsSCH0201U99GrdOrderListResult() { }

	}
}