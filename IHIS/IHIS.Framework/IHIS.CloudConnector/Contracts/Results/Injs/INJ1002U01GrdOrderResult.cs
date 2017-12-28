using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Injs;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1002U01GrdOrderResult : AbstractContractResult
	{
		private List<INJ1002U01GrdOrderListItemInfo> _grdOrderList = new List<INJ1002U01GrdOrderListItemInfo>();

		public List<INJ1002U01GrdOrderListItemInfo> GrdOrderList
		{
			get { return this._grdOrderList; }
			set { this._grdOrderList = value; }
		}

		public INJ1002U01GrdOrderResult() { }

	}
}