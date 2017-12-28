using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U17LoadHangwiOrder3Result : AbstractContractResult
	{
		private List<OCS0103U17GrdSearchOrderInfo> _grdSearchOrderInfo = new List<OCS0103U17GrdSearchOrderInfo>();

		public List<OCS0103U17GrdSearchOrderInfo> GrdSearchOrderInfo
		{
			get { return this._grdSearchOrderInfo; }
			set { this._grdSearchOrderInfo = value; }
		}

		public OCS0103U17LoadHangwiOrder3Result() { }

	}
}