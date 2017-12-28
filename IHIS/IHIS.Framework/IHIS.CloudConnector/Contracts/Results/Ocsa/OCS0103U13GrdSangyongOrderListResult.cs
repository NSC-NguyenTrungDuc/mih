using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U13GrdSangyongOrderListResult : AbstractContractResult
	{
		private List<OCS0103U13GrdSangyongOrderListInfo> _grdSangyongItem = new List<OCS0103U13GrdSangyongOrderListInfo>();

		public List<OCS0103U13GrdSangyongOrderListInfo> GrdSangyongItem
		{
			get { return this._grdSangyongItem; }
			set { this._grdSangyongItem = value; }
		}

		public OCS0103U13GrdSangyongOrderListResult() { }

	}
}