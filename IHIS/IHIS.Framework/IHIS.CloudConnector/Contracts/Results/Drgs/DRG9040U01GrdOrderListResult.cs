using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG9040U01GrdOrderListResult : AbstractContractResult
	{
		private List<DRG9040U01GrdOrderListInfo> _grdOrderListInfo = new List<DRG9040U01GrdOrderListInfo>();

		public List<DRG9040U01GrdOrderListInfo> GrdOrderListInfo
		{
			get { return this._grdOrderListInfo; }
			set { this._grdOrderListInfo = value; }
		}

		public DRG9040U01GrdOrderListResult() { }

	}
}