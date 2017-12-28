using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U10GrdDrgOrderResult : AbstractContractResult
	{
		private List<OCS0103U10GrdDrgOrderInfo> _drgOrderItem = new List<OCS0103U10GrdDrgOrderInfo>();

		public List<OCS0103U10GrdDrgOrderInfo> DrgOrderItem
		{
			get { return this._drgOrderItem; }
			set { this._drgOrderItem = value; }
		}

		public OCS0103U10GrdDrgOrderResult() { }

	}
}