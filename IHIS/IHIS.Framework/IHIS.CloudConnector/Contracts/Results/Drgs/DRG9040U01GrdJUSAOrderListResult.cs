using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG9040U01GrdJUSAOrderListResult : AbstractContractResult
	{
		private List<DRG9040U01GrdJUSAOrderListInfo> _grdOrderListInfo = new List<DRG9040U01GrdJUSAOrderListInfo>();

		public List<DRG9040U01GrdJUSAOrderListInfo> GrdOrderListInfo
		{
			get { return this._grdOrderListInfo; }
			set { this._grdOrderListInfo = value; }
		}

		public DRG9040U01GrdJUSAOrderListResult() { }

	}
}