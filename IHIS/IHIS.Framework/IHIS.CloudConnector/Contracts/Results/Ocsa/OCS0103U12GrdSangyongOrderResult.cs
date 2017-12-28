using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12GrdSangyongOrderResult : AbstractContractResult
	{
		private List<OCS0103U12GrdSangyongOrderInfo> _grdSangyongList = new List<OCS0103U12GrdSangyongOrderInfo>();

		public List<OCS0103U12GrdSangyongOrderInfo> GrdSangyongList
		{
			get { return this._grdSangyongList; }
			set { this._grdSangyongList = value; }
		}

		public OCS0103U12GrdSangyongOrderResult() { }

	}
}