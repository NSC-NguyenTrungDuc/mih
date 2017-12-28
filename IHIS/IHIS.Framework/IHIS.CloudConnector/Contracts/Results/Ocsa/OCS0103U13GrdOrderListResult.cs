using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U13GrdOrderListResult : AbstractContractResult
	{
		private List<OCS0103U13GrdOrderListInfo> _grdOrderListItem = new List<OCS0103U13GrdOrderListInfo>();

		public List<OCS0103U13GrdOrderListInfo> GrdOrderListItem
		{
			get { return this._grdOrderListItem; }
			set { this._grdOrderListItem = value; }
		}

		public OCS0103U13GrdOrderListResult() { }

	}
}