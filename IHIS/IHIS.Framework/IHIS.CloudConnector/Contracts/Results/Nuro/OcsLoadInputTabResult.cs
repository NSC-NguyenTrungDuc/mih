using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class OcsLoadInputTabResult : AbstractContractResult
	{
		private List<OcsLoadInputTabListItemInfo> _tabList = new List<OcsLoadInputTabListItemInfo>();

		public List<OcsLoadInputTabListItemInfo> TabList
		{
			get { return this._tabList; }
			set { this._tabList = value; }
		}

		public OcsLoadInputTabResult() { }

	}
}