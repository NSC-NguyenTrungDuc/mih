using IHIS.CloudConnector.Contracts.Models.System;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class ComboListByCodeTypeResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _comboListItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ComboListItem
		{
			get { return this._comboListItem; }
			set { this._comboListItem = value; }
		}

		public ComboListByCodeTypeResult() { }

	}
}