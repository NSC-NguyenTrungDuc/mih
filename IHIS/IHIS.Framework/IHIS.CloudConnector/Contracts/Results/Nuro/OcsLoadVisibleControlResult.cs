using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class OcsLoadVisibleControlResult : AbstractContractResult
	{
		private List<OcsLoadVisibleControlListItemInfo> _visibleControlList = new List<OcsLoadVisibleControlListItemInfo>();

		public List<OcsLoadVisibleControlListItemInfo> VisibleControlList
		{
			get { return this._visibleControlList; }
			set { this._visibleControlList = value; }
		}

		public OcsLoadVisibleControlResult() { }

	}
}