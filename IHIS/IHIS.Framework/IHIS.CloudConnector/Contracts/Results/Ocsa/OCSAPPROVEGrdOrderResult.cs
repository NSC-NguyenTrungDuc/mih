using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCSAPPROVEGrdOrderResult : AbstractContractResult
	{
		private List<OCSAPPROVEGrdOrderInfo> _grdOrderInfo = new List<OCSAPPROVEGrdOrderInfo>();

		public List<OCSAPPROVEGrdOrderInfo> GrdOrderInfo
		{
			get { return this._grdOrderInfo; }
			set { this._grdOrderInfo = value; }
		}

		public OCSAPPROVEGrdOrderResult() { }

	}
}