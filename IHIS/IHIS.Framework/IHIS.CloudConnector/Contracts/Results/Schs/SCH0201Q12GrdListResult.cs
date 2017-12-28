using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH0201Q12GrdListResult : AbstractContractResult
	{
		private List<SCH0201Q12GrdListItemInfo> _grdListItem = new List<SCH0201Q12GrdListItemInfo>();

		public List<SCH0201Q12GrdListItemInfo> GrdListItem
		{
			get { return this._grdListItem; }
			set { this._grdListItem = value; }
		}

		public SCH0201Q12GrdListResult() { }

	}
}