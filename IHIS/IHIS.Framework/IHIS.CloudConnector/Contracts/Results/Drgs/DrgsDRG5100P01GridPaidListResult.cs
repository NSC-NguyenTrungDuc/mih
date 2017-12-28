using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01GridPaidListResult : AbstractContractResult
	{
		private List<DrgsDRG5100P01GridPaidListItemInfo> _paidOrderList = new List<DrgsDRG5100P01GridPaidListItemInfo>();

		public List<DrgsDRG5100P01GridPaidListItemInfo> PaidOrderList
		{
			get { return this._paidOrderList; }
			set { this._paidOrderList = value; }
		}

		public DrgsDRG5100P01GridPaidListResult() { }

	}
}