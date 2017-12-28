using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Injs;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ0101U01GrdDetailResult : AbstractContractResult
	{
		private List<INJ0101U01GrdDetailItemInfo> _grdDetailItemInfo = new List<INJ0101U01GrdDetailItemInfo>();

		public List<INJ0101U01GrdDetailItemInfo> GrdDetailItemInfo
		{
			get { return this._grdDetailItemInfo; }
			set { this._grdDetailItemInfo = value; }
		}

		public INJ0101U01GrdDetailResult() { }

	}
}