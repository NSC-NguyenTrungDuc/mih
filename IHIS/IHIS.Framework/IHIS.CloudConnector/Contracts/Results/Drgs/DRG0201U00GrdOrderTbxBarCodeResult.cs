using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0201U00GrdOrderTbxBarCodeResult : AbstractContractResult
	{
		private List<DRG0201U00GrdOrderInfo> _grdOrderItem = new List<DRG0201U00GrdOrderInfo>();
		private String _actYn;

		public List<DRG0201U00GrdOrderInfo> GrdOrderItem
		{
			get { return this._grdOrderItem; }
			set { this._grdOrderItem = value; }
		}

		public String ActYn
		{
			get { return this._actYn; }
			set { this._actYn = value; }
		}

		public DRG0201U00GrdOrderTbxBarCodeResult() { }

	}
}