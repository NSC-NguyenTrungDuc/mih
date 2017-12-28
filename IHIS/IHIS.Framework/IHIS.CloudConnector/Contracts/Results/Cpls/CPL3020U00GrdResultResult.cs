using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3020U00GrdResultResult : AbstractContractResult
	{
		private List<CPL3020U00GrdResultListItemInfo> _grdResultItem = new List<CPL3020U00GrdResultListItemInfo>();

		public List<CPL3020U00GrdResultListItemInfo> GrdResultItem
		{
			get { return this._grdResultItem; }
			set { this._grdResultItem = value; }
		}

		public CPL3020U00GrdResultResult() { }

	}
}