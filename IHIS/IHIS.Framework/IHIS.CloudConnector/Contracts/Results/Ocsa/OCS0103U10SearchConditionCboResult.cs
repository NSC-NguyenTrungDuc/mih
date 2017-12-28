using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U10SearchConditionCboResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _cboSearchConditionItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> CboSearchConditionItem
		{
			get { return this._cboSearchConditionItem; }
			set { this._cboSearchConditionItem = value; }
		}

		public OCS0103U10SearchConditionCboResult() { }

	}
}