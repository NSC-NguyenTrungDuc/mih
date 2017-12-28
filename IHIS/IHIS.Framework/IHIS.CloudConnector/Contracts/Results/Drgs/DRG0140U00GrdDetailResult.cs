using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0140U00GrdDetailResult : AbstractContractResult
	{
		private List<DRG0140U00GrdDetailInfo> _grdDetailItem = new List<DRG0140U00GrdDetailInfo>();

		public List<DRG0140U00GrdDetailInfo> GrdDetailItem
		{
			get { return this._grdDetailItem; }
			set { this._grdDetailItem = value; }
		}

		public DRG0140U00GrdDetailResult() { }

	}
}