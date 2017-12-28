using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U16GrdSangyongOrderResult : AbstractContractResult
	{
		private List<OCS0103U16GrdSangyongOrderInfo> _sangyongOrderItem = new List<OCS0103U16GrdSangyongOrderInfo>();

		public List<OCS0103U16GrdSangyongOrderInfo> SangyongOrderItem
		{
			get { return this._sangyongOrderItem; }
			set { this._sangyongOrderItem = value; }
		}

		public OCS0103U16GrdSangyongOrderResult() { }

	}
}