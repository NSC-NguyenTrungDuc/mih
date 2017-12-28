using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201Q04GetCboListResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _cboItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> CboItem
		{
			get { return this._cboItem; }
			set { this._cboItem = value; }
		}

		public SchsSCH0201Q04GetCboListResult() { }

	}
}