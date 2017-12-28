using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class ComboResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _comboItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ComboItem
		{
			get { return this._comboItem; }
			set { this._comboItem = value; }
		}

		public ComboResult() { }

	}
}