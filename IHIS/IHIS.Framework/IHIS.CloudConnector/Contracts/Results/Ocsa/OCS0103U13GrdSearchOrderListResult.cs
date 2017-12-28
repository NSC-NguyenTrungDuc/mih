using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U13GrdSearchOrderListResult : AbstractContractResult
	{
		private List<OCS0103U13GrdSearchOrderListInfo> _grdSearchOrderListItem = new List<OCS0103U13GrdSearchOrderListInfo>();

		public List<OCS0103U13GrdSearchOrderListInfo> GrdSearchOrderListItem
		{
			get { return this._grdSearchOrderListItem; }
			set { this._grdSearchOrderListItem = value; }
		}

		public OCS0103U13GrdSearchOrderListResult() { }

	}
}