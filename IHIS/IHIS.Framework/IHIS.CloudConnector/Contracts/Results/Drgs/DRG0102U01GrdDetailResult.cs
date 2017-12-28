using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0102U01GrdDetailResult : AbstractContractResult
	{
		private List<DRG0102U01GrdDetailItemInfo> _grdDetailItemInfo = new List<DRG0102U01GrdDetailItemInfo>();

		public List<DRG0102U01GrdDetailItemInfo> GrdDetailItemInfo
		{
			get { return this._grdDetailItemInfo; }
			set { this._grdDetailItemInfo = value; }
		}

		public DRG0102U01GrdDetailResult() { }

	}
}