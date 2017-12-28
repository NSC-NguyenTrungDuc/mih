using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U17LoadJaeryoOrderResult : AbstractContractResult
	{
		private List<OCS0103U17GrdJaeryoOrderInfo> _grdList = new List<OCS0103U17GrdJaeryoOrderInfo>();

		public List<OCS0103U17GrdJaeryoOrderInfo> GrdList
		{
			get { return this._grdList; }
			set { this._grdList = value; }
		}

		public OCS0103U17LoadJaeryoOrderResult() { }

	}
}