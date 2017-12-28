using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System

{
    [Serializable] 
	public class GetDataForComboResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _comboDepartmentItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ComboDepartmentItem
		{
			get { return this._comboDepartmentItem; }
			set { this._comboDepartmentItem = value; }
		}

		public GetDataForComboResult() { }

	}
}