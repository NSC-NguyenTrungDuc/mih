using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Xrts;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00GrdJaeryoColumnChangedResult : AbstractContractResult
	{
		private List<XRT0201U00GrdJaeryoColumnChangedItemInfo> _grdJaeryoItemInfo = new List<XRT0201U00GrdJaeryoColumnChangedItemInfo>();

		public List<XRT0201U00GrdJaeryoColumnChangedItemInfo> GrdJaeryoItemInfo
		{
			get { return this._grdJaeryoItemInfo; }
			set { this._grdJaeryoItemInfo = value; }
		}

		public XRT0201U00GrdJaeryoColumnChangedResult() { }

	}
}