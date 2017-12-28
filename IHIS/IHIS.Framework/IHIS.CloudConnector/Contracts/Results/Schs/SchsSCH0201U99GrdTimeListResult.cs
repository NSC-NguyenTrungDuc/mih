using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201U99GrdTimeListResult : AbstractContractResult
	{
		private List<SchsSCH0201U99GrdTimeListInfo> _orderList = new List<SchsSCH0201U99GrdTimeListInfo>();

		public List<SchsSCH0201U99GrdTimeListInfo> OrderList
		{
			get { return this._orderList; }
			set { this._orderList = value; }
		}

		public SchsSCH0201U99GrdTimeListResult() { }

	}
}