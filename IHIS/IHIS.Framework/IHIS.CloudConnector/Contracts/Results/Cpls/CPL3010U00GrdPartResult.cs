using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3010U00GrdPartResult : AbstractContractResult
	{
		private List<CPL3010U00GrdPartListItemInfo> _grdPartInfo = new List<CPL3010U00GrdPartListItemInfo>();

		public List<CPL3010U00GrdPartListItemInfo> GrdPartInfo
		{
			get { return this._grdPartInfo; }
			set { this._grdPartInfo = value; }
		}

		public CPL3010U00GrdPartResult() { }

	}
}