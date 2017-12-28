using IHIS.CloudConnector.Contracts.Models.Cpls;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL0000Q00LayOrderResult : AbstractContractResult
	{
		private List<CPL0000Q00LayOrderListItemInfo> _layOrderList = new List<CPL0000Q00LayOrderListItemInfo>();

		public List<CPL0000Q00LayOrderListItemInfo> LayOrderList
		{
			get { return this._layOrderList; }
			set { this._layOrderList = value; }
		}

		public CPL0000Q00LayOrderResult() { }

	}
}