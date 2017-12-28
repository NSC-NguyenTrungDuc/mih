using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12LoadDrgOrderResult : AbstractContractResult
	{
		private List<OCS0103U12LoadDrgOrderInfo> _drgOrderList = new List<OCS0103U12LoadDrgOrderInfo>();

		public List<OCS0103U12LoadDrgOrderInfo> DrgOrderList
		{
			get { return this._drgOrderList; }
			set { this._drgOrderList = value; }
		}

		public OCS0103U12LoadDrgOrderResult() { }

	}
}