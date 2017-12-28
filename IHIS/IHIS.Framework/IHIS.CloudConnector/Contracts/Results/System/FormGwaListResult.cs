using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class FormGwaListResult : AbstractContractResult
	{
		private List<FormGwaItemInfo> _itemInfo = new List<FormGwaItemInfo>();

		public List<FormGwaItemInfo> ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public FormGwaListResult() { }

	}
}