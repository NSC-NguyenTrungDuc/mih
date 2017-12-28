using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG9040U01GrdOrderResult : AbstractContractResult
	{
		private List<DRG9040U01GrdOrderInfo> _grdOrderInfo = new List<DRG9040U01GrdOrderInfo>();

		public List<DRG9040U01GrdOrderInfo> GrdOrderInfo
		{
			get { return this._grdOrderInfo; }
			set { this._grdOrderInfo = value; }
		}

		public DRG9040U01GrdOrderResult() { }

	}
}