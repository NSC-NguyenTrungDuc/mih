using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Xrts;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00GrdRadioListResult : AbstractContractResult
	{
		private List<XRT0201U00GrdRadioListItemInfo> _grdRadioListItemInfo = new List<XRT0201U00GrdRadioListItemInfo>();

		public List<XRT0201U00GrdRadioListItemInfo> GrdRadioListItemInfo
		{
			get { return this._grdRadioListItemInfo; }
			set { this._grdRadioListItemInfo = value; }
		}

		public XRT0201U00GrdRadioListResult() { }

	}
}