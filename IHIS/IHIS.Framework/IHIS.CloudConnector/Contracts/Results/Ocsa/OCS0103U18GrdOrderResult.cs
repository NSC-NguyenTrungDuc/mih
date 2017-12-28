using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U18GrdOrderResult : AbstractContractResult
	{
		private List<OCS0103U13GrdOrderListInfo> _gridOrderInfo = new List<OCS0103U13GrdOrderListInfo>();

		public List<OCS0103U13GrdOrderListInfo> GridOrderInfo
		{
			get { return this._gridOrderInfo; }
			set { this._gridOrderInfo = value; }
		}

		public OCS0103U18GrdOrderResult() { }

	}
}