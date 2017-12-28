using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class CboSearchConditionResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _info1 = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> Info1
		{
			get { return this._info1; }
			set { this._info1 = value; }
		}

		public CboSearchConditionResult() { }

	}
}