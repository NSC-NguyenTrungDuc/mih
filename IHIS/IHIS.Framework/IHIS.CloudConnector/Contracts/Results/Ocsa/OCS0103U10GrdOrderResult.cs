using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U10GrdOrderResult : AbstractContractResult
	{
		private List<OCS0103U13GrdOrderListInfo> _grdOrderItem = new List<OCS0103U13GrdOrderListInfo>();

		public List<OCS0103U13GrdOrderListInfo> GrdOrderItem
		{
			get { return this._grdOrderItem; }
			set { this._grdOrderItem = value; }
		}

		public OCS0103U10GrdOrderResult() { }

	}
}