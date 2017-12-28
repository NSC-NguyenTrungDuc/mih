using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG9040U01GrdOrderListOutResult : AbstractContractResult
	{
		private List<DRG9040U01GrdOrderListOutInfo> _grdOrderListOutInfo = new List<DRG9040U01GrdOrderListOutInfo>();

		public List<DRG9040U01GrdOrderListOutInfo> GrdOrderListOutInfo
		{
			get { return this._grdOrderListOutInfo; }
			set { this._grdOrderListOutInfo = value; }
		}

		public DRG9040U01GrdOrderListOutResult() { }

	}
}