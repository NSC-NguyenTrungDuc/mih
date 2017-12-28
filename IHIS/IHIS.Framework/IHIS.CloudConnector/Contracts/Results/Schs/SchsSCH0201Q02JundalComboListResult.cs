using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201Q02JundalComboListResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _comboListItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ComboListItem
		{
			get { return this._comboListItem; }
			set { this._comboListItem = value; }
		}

		public SchsSCH0201Q02JundalComboListResult() { }

	}
}