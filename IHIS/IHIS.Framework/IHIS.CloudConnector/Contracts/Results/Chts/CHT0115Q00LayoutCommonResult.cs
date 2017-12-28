using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
	public class CHT0115Q00LayoutCommonResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _layoutCommonInfo = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> LayoutCommonInfo
		{
			get { return this._layoutCommonInfo; }
			set { this._layoutCommonInfo = value; }
		}

		public CHT0115Q00LayoutCommonResult() { }

	}
}