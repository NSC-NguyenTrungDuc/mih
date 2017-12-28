using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201Q01ReserListCboResult : AbstractContractResult
	{
		private List<SchsSCH0201Q01ReserListItemInfo> _reserListItem = new List<SchsSCH0201Q01ReserListItemInfo>();
		private List<ComboListItemInfo> _comboListItem = new List<ComboListItemInfo>();

		public List<SchsSCH0201Q01ReserListItemInfo> ReserListItem
		{
			get { return this._reserListItem; }
			set { this._reserListItem = value; }
		}

		public List<ComboListItemInfo> ComboListItem
		{
			get { return this._comboListItem; }
			set { this._comboListItem = value; }
		}

		public SchsSCH0201Q01ReserListCboResult() { }

	}
}