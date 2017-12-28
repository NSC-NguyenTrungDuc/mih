using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Xrts;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00GrdOrderResult : AbstractContractResult
	{
		private List<XRT0201U00GrdOrderItemInfo> _grdOrderItemInfo = new List<XRT0201U00GrdOrderItemInfo>();

		public List<XRT0201U00GrdOrderItemInfo> GrdOrderItemInfo
		{
			get { return this._grdOrderItemInfo; }
			set { this._grdOrderItemInfo = value; }
		}

		public XRT0201U00GrdOrderResult() { }

	}
}