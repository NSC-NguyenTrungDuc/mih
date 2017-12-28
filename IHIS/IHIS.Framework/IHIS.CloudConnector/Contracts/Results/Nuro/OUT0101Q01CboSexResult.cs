using IHIS.CloudConnector.Contracts.Models.System;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class OUT0101Q01CboSexResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _item = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> Item
		{
			get { return this._item; }
			set { this._item = value; }
		}

		public OUT0101Q01CboSexResult() { }

	}
}