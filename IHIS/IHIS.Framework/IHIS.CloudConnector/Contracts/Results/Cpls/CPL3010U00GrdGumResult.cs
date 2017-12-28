using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3010U00GrdGumResult : AbstractContractResult
	{
		private List<CPL3010U00GrdGumListItemInfo> _grdGumItem = new List<CPL3010U00GrdGumListItemInfo>();

		public List<CPL3010U00GrdGumListItemInfo> GrdGumItem
		{
			get { return this._grdGumItem; }
			set { this._grdGumItem = value; }
		}

		public CPL3010U00GrdGumResult() { }

	}
}