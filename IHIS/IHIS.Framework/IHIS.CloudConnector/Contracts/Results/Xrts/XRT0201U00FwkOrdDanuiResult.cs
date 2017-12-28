using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Xrts;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00FwkOrdDanuiResult : AbstractContractResult
	{
		private List<XRT0201U00FwkOrdDanuiItemInfo> _fwkOrdDanuiItemInfo = new List<XRT0201U00FwkOrdDanuiItemInfo>();

		public List<XRT0201U00FwkOrdDanuiItemInfo> FwkOrdDanuiItemInfo
		{
			get { return this._fwkOrdDanuiItemInfo; }
			set { this._fwkOrdDanuiItemInfo = value; }
		}

		public XRT0201U00FwkOrdDanuiResult() { }

	}
}