using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U13CboListResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _suryangCboItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _nalsuCboItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _searchConditionCboItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _orderGubunBasCboItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> SuryangCboItem
		{
			get { return this._suryangCboItem; }
			set { this._suryangCboItem = value; }
		}

		public List<ComboListItemInfo> NalsuCboItem
		{
			get { return this._nalsuCboItem; }
			set { this._nalsuCboItem = value; }
		}

		public List<ComboListItemInfo> SearchConditionCboItem
		{
			get { return this._searchConditionCboItem; }
			set { this._searchConditionCboItem = value; }
		}

		public List<ComboListItemInfo> OrderGubunBasCboItem
		{
			get { return this._orderGubunBasCboItem; }
			set { this._orderGubunBasCboItem = value; }
		}

		public OCS0103U13CboListResult() { }

	}
}