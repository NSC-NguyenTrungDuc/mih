using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OCS1003P01MakeInputGubunTabResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _tabList = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> TabList
		{
			get { return this._tabList; }
			set { this._tabList = value; }
		}

		public OCS1003P01MakeInputGubunTabResult() { }

	}
}